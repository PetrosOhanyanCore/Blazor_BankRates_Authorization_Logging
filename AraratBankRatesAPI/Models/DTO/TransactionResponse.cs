using AraratBankRatesAPI.Models.Domain;

namespace AraratBankRatesAPI.Models.DTO
{
    public class TransactionResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Exchange Exchange { get; set; }
        public double ExchangeRate { get; set; }
        public double GivenAmount { get; set; }
        public double ReceivedAmount { get; set; }
        public string TransactionStatus { get; set; }
    }
}