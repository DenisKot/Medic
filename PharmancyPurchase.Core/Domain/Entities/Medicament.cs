namespace PharmancyPurchase.Core.Domain.Entities
{
    using PharmancyPurchase.Domain;

    public class Medicament : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int ItemsAvailable { get; set; }

        public double Price { get; set; }

        public string Vendor { get; set; }
    }
}