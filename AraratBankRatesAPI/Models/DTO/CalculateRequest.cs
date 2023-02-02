namespace AraratBankRatesAPI.Models.DTO
{
    public class Calculate
    {
        public ExchangeRequest GivedExchange { get; set; }
        public ExchangeRequest ReceivenExchange { get; set; }
        public double GivedAmount { get; set; }
    }
}
