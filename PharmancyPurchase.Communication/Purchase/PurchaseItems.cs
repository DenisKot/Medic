namespace PharmancyPurchase.Communication.Purchase
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PurchaseItems
    {
        [JsonProperty("items")]
        public IEnumerable<Purchase> Items { get; set; }
    }
}