namespace PharmacyPurchase.Presentation.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PharmancyPurchase.Application.Orders;
    using PharmancyPurchase.Application.Service;
    using PharmancyPurchase.Core.Domain.Entities;

    public class OrdersController : Controller
    {
        private readonly IOrdersAppService ordersAppService;

        public OrdersController(IOrdersAppService ordersAppService)
        {
            this.ordersAppService = ordersAppService;
        }

        public async Task<IActionResult> List()
        {
            var list = await this.ordersAppService.GetPossibleOrdersAsync();
            this.ViewData["List"] = list;

            return this.View();
        }
    }
}