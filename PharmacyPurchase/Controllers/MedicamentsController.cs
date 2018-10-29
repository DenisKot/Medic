namespace PharmacyPurchase.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PharmancyPurchase.Application.Service;
    using PharmancyPurchase.Core.Domain.Entities;

    public class MedicamentsController : Controller
    {
        private readonly IService<Medicament> medicamentsService;

        public MedicamentsController(IService<Medicament> medicamentsService)
        {
            this.medicamentsService = medicamentsService;
        }

        public IActionResult List()
        {
            var list = this.medicamentsService.GetAll();
            this.ViewData["List"] = list;

            return this.View();
        }
    }
}