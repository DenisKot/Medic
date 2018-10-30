namespace PharmancyPurchase.Application.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Communication;
    using Communication.Orders;
    using Core;
    using Core.Domain.Entities;
    using Crosscutting;
    using Newtonsoft.Json;

    public interface IOrdersAppService
    {
        Task<IEnumerable<OrderDto>> GetPossibleOrdersAsync();
    }

    public class OrdersAppService : IOrdersAppService
    {
        private readonly IRepository<Medicament> medicamentRepository;
        private readonly IRepository<MedicamentSale> medicamentSaleRepository;
        private readonly IMappingService mappingService;
        private readonly IConfigurationService configurationService;

        public OrdersAppService(
            IRepository<Medicament> medicamentRepository,
            IMappingService mappingService,
            IRepository<MedicamentSale> medicamentSaleRepository,
            IConfigurationService configurationService)
        {
            this.medicamentRepository = medicamentRepository;
            this.mappingService = mappingService;
            this.medicamentSaleRepository = medicamentSaleRepository;
            this.configurationService = configurationService;
        }

        public async Task<IEnumerable<OrderDto>> GetPossibleOrdersAsync()
        {
            var medicaments = await this.medicamentRepository.GetAllListAsync();
            var orders = this.mappingService.Map<IEnumerable<OrderDto>>(medicaments);

            foreach (var order in orders)
            {
                order.OrderDtails = this.medicamentSaleRepository.GetAll()
                    .Where(x => x.MedicamentId == order.Id)
                    .Select(x => new OrderDetailDto
                    {
                        ItemsCount = x.Count,
                        OrderDate = x.Sale.DateTime
                    }).ToList();
            }

            if (!string.IsNullOrEmpty(this.configurationService.ExternalOrderServiceUrl))
            {
                try
                {
                    orders = await this.GetExternalSystemDataAsync(orders);
                }
                catch (Exception e)
                {
                    // dummy
                }
            }

            return orders;
        }

        private async Task<IEnumerable<OrderDto>> GetExternalSystemDataAsync(IEnumerable<OrderDto> list)
        {
            // Serialize our concrete class into a JSON String
            var stringPayload = JsonConvert.SerializeObject(list);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                // Do the actual request and await the response
                var httpResponse = await httpClient.PostAsync(this.configurationService.ExternalOrderServiceUrl, httpContent);

                // If the response contains content we want to read it!
                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<OrderDto>>(responseContent);
                }
            }

            throw new Exception("Exteranl system error");
        }
    }
}