namespace PharmancyPurchase.Communication
{
    using System;

    public class OrderDetailDto
    {
        public DateTime OrderDate { get; set; }
        public int ItemsCount { get; set; }
    }
}