using Microsoft.Extensions.Options;

namespace AraratBankRatesAPI.Models.DTO
{
    public class CurrentRateAPIModel
    {
        public string URL { get; set; }
        public string HeaderKey { get; set; }
        public string HeaderValue { get; set; }
    }
}
