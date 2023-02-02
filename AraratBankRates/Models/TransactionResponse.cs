using System.Text.Json.Serialization;

namespace AraratBankRates.Models
{
    public class TransactionResponse
    {
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("exchange")]
        public Exchange? Exchange { get; set; }

        [JsonPropertyName("exchangeRate")]
        public double ExchangeRate { get; set; }

        [JsonPropertyName("givenAmount")]
        public double GivenAmount { get; set; }

        [JsonPropertyName("receivedAmount")]
        public double ReceivedAmount { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonIgnore]
        public string? transactionStatus { get; set; }
    }
}
