namespace PharmacyPurchase.Presentation.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using PharmancyPurchase.Application.Service;
    using PharmancyPurchase.Core.Domain.Entities;

    public class SalesController : Controller
    {
        private readonly IService<Sale> saleService;
        private readonly IService<MedicamentSale> medicamentSaleService;

        public SalesController(IService<Sale> saleService, IService<MedicamentSale> medicamentSaleService)
        {
            this.saleService = saleService;
            this.medicamentSaleService = medicamentSaleService;
        }

        public IActionResult List()
        {
            var list = this.saleService.GetList(x => x.MedicamentSales);
            Func<Sale, string> func = this.GetBoughtItems;

            this.ViewData["List"] = list;
            this.ViewData["GetItmes"] = func;

            return this.View();
        }

        private string GetBoughtItems(Sale sale)
        {
            var sales = this.medicamentSaleService.GetAll().Where(x => x.SaleId == sale.Id).Select(x => new {x.Medicament.Title, x.Count}).ToList();

            //ToDo: not working MedicamentSales EF mapping
            return string.Join(", ", sales
                .Select(x => x.Count > 1 ? $"{x.Title} ({x.Count})" : x.Title)
                .ToArray());
        }
    }
}