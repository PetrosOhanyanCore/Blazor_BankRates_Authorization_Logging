using AraratBankRatesAPI.Models.Domain;
using AraratBankRatesAPI.Models.DTO;
using AraratBankRatesAPI.Repositories.Abstract;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace AraratBankRatesAPI.Repositories.Domain
{
    public class TransactionService : ITransactionService
    {
        private readonly DatabaseContext _context;
        private readonly IOptions<CurrentRateAPIModel> _options;
        private readonly string _baseUrl;

        public TransactionService(DatabaseContext context, IOptions<CurrentRateAPIModel> options)
        {
            _context = context;
            _options = options;
            _baseUrl = "https://api.apilayer.com/exchangerates_data/latest";
        }

        public async Task<double> Calculate(double givenAmount, string givenExchangeType, string receivenExchangeType, RateModel rateModel)
        {
            if (givenExchangeType == rateModel.@base)
            {
                var result = givenAmount * (double)rateModel.rates.GetType().GetProperty(receivenExchangeType).GetValue(rateModel.rates, null);
                return result;
            }

            else if (receivenExchangeType == rateModel.@base)
            {
                var result = givenAmount * (double)rateModel.rates.GetType().GetProperty(receivenExchangeType).GetValue(rateModel.rates, null);
                return result;
            }

            else
            {
                var givenTypeValue = (double)rateModel.rates.GetType().GetProperty(givenExchangeType).GetValue(rateModel.rates, null);
                var receivenTypeValue = (double)rateModel.rates.GetType().GetProperty(receivenExchangeType).GetValue(rateModel.rates, null);

                var result = (givenAmount * receivenTypeValue) / givenTypeValue;
                return result;
            }
        }

        public async Task Create(TransactionRequest request)
        {
            Transaction transaction = new Transaction
            {
                CreatedDate = request.CreatedDate,
                Exchange = new Exchange
                {
                    ExchangeCode = request.Exchange.ExchangeCode,
                    ExchangeType = request.Exchange.ExchangeType
                },
                ExchangeRate = request.ExchangeRate,
                GivenAmount = request.GivenAmount,
                ReceivedAmount = request.ReceivedAmount,
                UserId = request.UserId,
                TransactionStatus = "Success",
                ExchangeId = _context.Exchanges.Where
                (x => x.ExchangeCode == request.Exchange.ExchangeCode &&
                x.ExchangeType == request.Exchange.ExchangeType)
                .FirstOrDefault().Id,
                ApplicationUser = _context.Users.Where(x => x.Id == request.UserId).FirstOrDefault()

            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public async Task<List<TransactionResponse>> GetAll(string userId)
        {
            var response = _context.Transactions.Where(x => x.UserId == userId).ToList();

            var result = new List<TransactionResponse>();

            foreach (var item in response)
            {
                var transaction = new TransactionResponse
                {
                    CreatedDate = item.CreatedDate,
                    Exchange = new Exchange
                    {
                        ExchangeCode = _context.Exchanges.Where(s => s.Id == item.ExchangeId).FirstOrDefault().ExchangeCode,
                        ExchangeType = _context.Exchanges.Where(s => s.Id == item.ExchangeId).FirstOrDefault().ExchangeType,
                        Id = item.Exchange.Id
                    },
                    ExchangeRate = item.ExchangeRate,
                    GivenAmount = item.GivenAmount,
                    ReceivedAmount = item.ReceivedAmount,
                    Id = item.Id,
                    TransactionStatus = item.TransactionStatus
                };
                result.Add(transaction);
            }

            return result;
        }

        public Task<TransactionResponse> GetById(string userId, int id)
        {
            var response = _context.Transactions.Where(x => x.UserId == userId && x.Id == id).FirstOrDefault();

            var transaction = new TransactionResponse
            {
                CreatedDate = response.CreatedDate,
                Exchange = new Exchange
                {
                    ExchangeCode = _context.Exchanges.Where(s => s.Id == response.ExchangeId).FirstOrDefault().ExchangeCode,
                    ExchangeType = _context.Exchanges.Where(s => s.Id == response.ExchangeId).FirstOrDefault().ExchangeType,
                    Id = response.Exchange.Id
                },
                ExchangeRate = response.ExchangeRate,
                GivenAmount = response.GivenAmount,
                ReceivedAmount = response.ReceivedAmount,
                Id = response.Id,
                TransactionStatus = response.TransactionStatus
            };

            return Task.FromResult(transaction);
        }

        public async Task<RateModel> GetRates()
        {
            using HttpClient httpClient = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage();
            req.RequestUri = new Uri(_baseUrl);
            req.Method = HttpMethod.Get;
            req.Headers.Add("apikey", "vbjeljWWPNFs5FGuVoXeefSI6jdplMS1");
            HttpResponseMessage response = await httpClient.SendAsync(req);
            var responseString = await response.Content.ReadAsStringAsync();

            var RateModel = JsonSerializer.Deserialize<RateModel>(responseString);

            return RateModel;
        }
    }
}
