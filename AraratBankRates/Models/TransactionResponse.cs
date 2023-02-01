namespace AraratBankRates.Models
{
    public class TransactionResponse
    {
        public DateTime CreatedDate { get; set; }
        public Exchange? Exchange { get; set; }
        public double ExchangeRate { get; set; }
        public double GivenAmount { get; set; }
        public double ReceivedAmount { get; set; }
        public int Id { get; set; }
        public string? transactionStatus { get; set; }
    }
}
