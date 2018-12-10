using System.Linq;
using PharmancyPurchase.Application.Service;
using PharmancyPurchase.Communication.Purchase;
using PharmancyPurchase.Core.Domain.Entities;

namespace PharmacyPurchase.Presentation.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PharmancyPurchase.Application.Orders;

    public class OrdersController : Controller
    {
        private readonly IOrdersAppService _ordersAppService;
        private readonly IService<Medicament> _medicamentsService;
        public OrdersController(IOrdersAppService ordersAppService, IService<Medicament> medicamentsService)
        {
            _ordersAppService = ordersAppService;
            _medicamentsService = medicamentsService;
        }

        public async Task<IActionResult> List()
        {
            var list = await _ordersAppService.GetPossibleOrdersAsync();
            this.ViewData["List"] = list;

            return this.View();
        }

        public async Task<IActionResult> NewOrder([FromBody] PurchaseItems items)
        {
            if (!items.Items.Any(x => x.Count > 0)) return BadRequest("Number of elements less than zero");
            {
                foreach (var item in items.Items)
                {
                    var medicament = _medicamentsService.GetBy(x => x.Id == item.Id);
                    medicament.ItemsAvailable += item.Count;
                    _medicamentsService.Update(medicament);
                }

                return Ok();
            }
        }
    }
}