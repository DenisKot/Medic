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

        public SalesController(IService<Sale> saleService)
        {
            this.saleService = saleService;
        }

        public IActionResult List()
        {
            var list = this.saleService.GetAll();
            Func<Sale, string> func = this.GetBoughtItems;

            this.ViewData["List"] = list;
            this.ViewData["GetItmes"] = func;

            return this.View();
        }

        private string GetBoughtItems(Sale sale)
        {
            //ToDo: not working MedicamentSales EF mapping
            return string.Join(", ", sale.MedicamentSales
                .SelectMany(x => x.Count > 1 ? $"{x.Medicament.Title} ({x.Count})" : x.Medicament.Title)
                .ToArray());
        }
    }
}