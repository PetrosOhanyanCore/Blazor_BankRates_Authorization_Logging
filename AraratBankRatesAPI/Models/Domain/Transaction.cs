namespace AraratBankRatesAPI.Models.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ExchangeId { get; set; }
        public Exchange Exchange { get; set; }
        public double ExchangeRate { get; set; }
        public double GivenAmount  { get; set; }
        public double ReceivedAmount { get; set; }
        public string TransactionStatus { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
