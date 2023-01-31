using AraratBankRatesAPI.Models.Domain;
using AraratBankRatesAPI.Models.DTO;
using AraratBankRatesAPI.Repositories.Abstract;

namespace AraratBankRatesAPI.Repositories.Domain
{
    public class TransactionService : ITransactionService
    {
        private readonly DatabaseContext _context;
        public TransactionService(DatabaseContext context)
        {
            _context = context;
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

        public Task<List<TransactionResponse>> GetAll(string userId)
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
                        ExchangeCode = item.Exchange.ExchangeCode,
                        ExchangeType = item.Exchange.ExchangeType,
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

            return Task.FromResult(result);
        }

        public Task<TransactionResponse> GetById(string userId, int id)
        {
            var response = _context.Transactions.Where(x => x.UserId == userId && x.Id == id).FirstOrDefault();

            var transaction = new TransactionResponse
            {
                CreatedDate = response.CreatedDate,
                Exchange = new Exchange
                {
                    ExchangeCode = response.Exchange.ExchangeCode,
                    ExchangeType = response.Exchange.ExchangeType,
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
    }
}
