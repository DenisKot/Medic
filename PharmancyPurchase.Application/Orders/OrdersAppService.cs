namespace PharmancyPurchase.Application.Orders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Communication;
    using Core;
    using Core.Domain.Entities;
    using Crosscutting;

    public interface IOrdersAppService
    {
        Task<IEnumerable<OrderDto>> GetPossibleOrdersAsync();
    }

    public class OrdersAppService : IOrdersAppService
    {
        private readonly IRepository<Medicament> medicamentRepository;
        private readonly IMappingService mappingService;

        public OrdersAppService(IRepository<Medicament> medicamentRepository, IMappingService mappingService)
        {
            this.medicamentRepository = medicamentRepository;
            this.mappingService = mappingService;
        }
        
        public async Task<IEnumerable<OrderDto>> GetPossibleOrdersAsync()
        {
            var medicaments = await this.medicamentRepository.GetAllListAsync();
            return this.mappingService.Map<IEnumerable<OrderDto>>(medicaments);
        }
    }
}