namespace AraratBankRates.Models
{
    public class TransactionResponse
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ExchangeRequest Exchange { get; set; }
        public double ExchangeRate { get; set; }
        public double GivenAmount { get; set; }
        public double ReceivedAmount { get; set; }
    }
}
