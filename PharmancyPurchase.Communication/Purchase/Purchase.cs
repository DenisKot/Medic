namespace PharmancyPurchase.Communication.Purchase
{
    using Newtonsoft.Json;

    public class Purchase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}