using System.Text.Json.Serialization;

namespace AraratBankRates.Models
{
    public class Exchange
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("exchangeType")]
        public string ExchangeType { get; set; }

        [JsonPropertyName("exchangeCode")]
        public string ExchangeCode { get; set; }

        [JsonIgnore]
        public string transactions { get; set; }



    }
}
