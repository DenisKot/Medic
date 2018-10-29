namespace PharmancyPurchase.Core.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using PharmancyPurchase.Domain;

    public class Sale : BaseEntity
    {
        public Sale()
        {
            this.MedicamentSales = new HashSet<MedicamentSale>();
        }

        public string Title
        {
            get => "Order №" + this.Id;
            set { }
        }

        public double TotalPrice { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<MedicamentSale> MedicamentSales { get; set; }
    }
}