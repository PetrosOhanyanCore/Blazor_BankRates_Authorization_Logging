using AraratBankRatesAPI.Models.Domain;

namespace AraratBankRatesAPI.Models.DTO
{
    public class TransactionResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Exchange Exchange { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal GivenAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public string TransactionStatus { get; set; }
    }
}
