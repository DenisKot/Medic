namespace PharmacyPurchase.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PharmancyPurchase.Application.Service;
    using PharmancyPurchase.Core.Domain.Entities;
    using System.Collections.Generic;
    using PharmancyPurchase.Communication.Purchase;

    public class MedicamentsController : Controller
    {
        private readonly IService<Medicament> medicamentsService;

        public MedicamentsController(IService<Medicament> medicamentsService)
        {
            this.medicamentsService = medicamentsService;
        }

        public IActionResult List()
        {
            var list = this.medicamentsService.GetList();
            //this.ViewData["List"] = list;

            return this.View(list);
        }

        [HttpGet]
        public IActionResult GetMedicament(int medicamentId)
        {
            var searchMedicament = this.medicamentsService.GetBy(m => m.Id == medicamentId);
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
            var id = this.medicamentsService.Create(medicament);

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult DeleteMedicament(int medicamentId)
        {
            var searchedMedicament = this.medicamentsService.GetBy(m => m.Id == medicamentId);
            if (searchedMedicament != null)
            {
                this.medicamentsService.Delete(searchedMedicament);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult DeleteFewMedicaments(List<int> medicamentIds)
        {
            var searchedMedicaments = GetListOfMedicaments(medicamentIds);

            foreach (var medicament in searchedMedicaments)
            {
                this.medicamentsService.Delete(medicament);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult ChangeMedicament(Medicament medicament)
        {
            this.medicamentsService.Update(medicament);

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Buy(PurchaseItems items)
        {
            
            return this.Ok();
        }

        private IEnumerable<Medicament> GetListOfMedicaments(IEnumerable<int> medicamentIds)
        {
            List<Medicament> result = new List<Medicament>();
            foreach (var id in medicamentIds)
            {
                var searchedMedicament = this.medicamentsService.GetBy(m => m.Id == id);
                if (searchedMedicament != null)
                {
                    result.Add(searchedMedicament);
                }
            }

            return result;
        }
    }
}