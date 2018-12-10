using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PharmacyPurchase.Presentation.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using PharmancyPurchase.Application.Service;
    using PharmancyPurchase.Core.Domain.Entities;
    using System.Collections.Generic;
    using PharmancyPurchase.Communication.Purchase;

    public class MedicamentsController : Controller
    {
        private readonly IService<Medicament> _medicamentsService;
        private readonly IService<Sale> _saleService;

        public MedicamentsController(IService<Medicament> medicamentsService, IService<Sale> saleService)
        {
            _medicamentsService = medicamentsService;
            _saleService = saleService;
        }

        public IActionResult List()
        {
            var list = this._medicamentsService.GetList();
            //this.ViewData["List"] = list;

            return this.View(list);
        }

        [HttpGet]
        public IActionResult GetMedicament(int medicamentId)
        {
            var searchMedicament = this._medicamentsService.GetBy(m => m.Id == medicamentId);
            return Ok(searchMedicament);
        }

        [HttpGet]
        public IActionResult AddNewMedicamentView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewMedicament(Medicament medicament)
        {
            var id = this._medicamentsService.Create(medicament);

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult DeleteMedicament(int medicamentId)
        {
            var searchedMedicament = this._medicamentsService.GetBy(m => m.Id == medicamentId);
            if (searchedMedicament != null)
            {
                this._medicamentsService.Delete(searchedMedicament);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult DeleteFewMedicaments(List<int> medicamentIds)
        {
            var searchedMedicaments = GetListOfMedicaments(medicamentIds);

            foreach (var medicament in searchedMedicaments)
            {
                this._medicamentsService.Delete(medicament);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult ChangeMedicament(Medicament medicament)
        {
            this._medicamentsService.Update(medicament);

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Buy([FromBody] PurchaseItems items)
        {
            if (!items.Items.Any(x => x.Count > 0)) return BadRequest("Number of elements less than zero");
            {
                var medicamentSales = new List<MedicamentSale>();
                double sum = 0;
                foreach (var item in items.Items)
                {
                    var med = _medicamentsService.GetBy(x => x.Id == item.Id);
                    var medicamentSale = new MedicamentSale
                    {
                        Medicament = med,
                        Count = item.Count
                    };

                    sum += med.Price * item.Count;

                    medicamentSales.Add(medicamentSale);
                    med.ItemsAvailable = med.ItemsAvailable - item.Count;
                    _medicamentsService.Update(med);
                }

                var sale = new Sale
                {
                    MedicamentSales = medicamentSales,
                    TotalPrice = sum
                };

                _saleService.Create(sale);

                return this.Ok();
            }

        }

        private IEnumerable<Medicament> GetListOfMedicaments(IEnumerable<int> medicamentIds)
        {
            List<Medicament> result = new List<Medicament>();
            foreach (var id in medicamentIds)
            {
                var searchedMedicament = this._medicamentsService.GetBy(m => m.Id == id);
                if (searchedMedicament != null)
                {
                    result.Add(searchedMedicament);
                }
            }

            return result;
        }
    }
}