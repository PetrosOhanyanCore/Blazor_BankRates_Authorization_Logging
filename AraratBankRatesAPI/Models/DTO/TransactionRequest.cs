using AraratBankRatesAPI.Models.Domain;

namespace AraratBankRatesAPI.Models.DTO
{
    public class TransactionRequest
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Exchange Exchange { get; set; }
        public double ExchangeRate { get; set; }
        public double GivenAmount { get; set; }
        public double ReceivedAmount { get; set; }
        public string UserId { get; set; }
    }
}
