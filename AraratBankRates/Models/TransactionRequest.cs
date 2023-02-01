namespace AraratBankRates.Models
{
    public class TransactionRequest
    {
        public DateTime CreatedDate { get; set; }
        public ExchangeRequest Exchange { get; set; }
        public double ExchangeRate { get; set; }
        public double GivenAmount { get; set; }
        public double ReceivedAmount { get; set; }
        public string UserId { get; set; }
    }
}
