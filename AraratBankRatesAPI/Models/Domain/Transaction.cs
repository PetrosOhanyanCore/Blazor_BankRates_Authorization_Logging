namespace AraratBankRatesAPI.Models.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Exchange Exchange { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal GivenAmount  { get; set; }
        public decimal ReceivedAmount { get; set; }
        public string TransactionStatus { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
