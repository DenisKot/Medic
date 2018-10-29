namespace PharmancyPurchase.Core.Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using PharmancyPurchase.Domain;

    public class MedicamentSale : BaseEntity
    {
        [Column("Medicament_Id")]
        public int MedicamentId { get; set; }
        public virtual Medicament Medicament { get; set; }

        [Column("Sale_Id")]
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }
        
        public int Count { get; set; }
    }
}