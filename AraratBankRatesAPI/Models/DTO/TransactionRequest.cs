using AraratBankRatesAPI.Models.Domain;

namespace AraratBankRatesAPI.Models.DTO
{
    public class TransactionRequest
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Exchange Exchange { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal GivenAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public string UserId { get; set; }
    }
}
