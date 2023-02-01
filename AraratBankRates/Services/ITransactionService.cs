using AraratBankRates.Models;

namespace AraratBankRates.Services
{
    public interface ITransactionService
    {
        Task CreateTransaction(TransactionRequest model);
        Task<List<TransactionResponse>> GetAll();
        Task<TransactionResponse> GetById(int id);
        Task<double> Calculate(Calculate calculate);
    }
}
