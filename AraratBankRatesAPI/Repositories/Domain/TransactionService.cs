using AraratBankRatesAPI.Models.DTO;
using AraratBankRatesAPI.Repositories.Abstract;

namespace AraratBankRatesAPI.Repositories.Domain
{
    public class TransactionService : ITransactionService
    {
        public Task Create(TransactionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse>> GetAll(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse> GetById(string userId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
