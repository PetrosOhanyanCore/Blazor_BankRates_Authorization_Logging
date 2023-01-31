using AraratBankRatesAPI.Models.DTO;

namespace AraratBankRatesAPI.Repositories.Abstract
{
    public interface ITransactionService
    {
        Task Create(TransactionRequest request);
        Task<TransactionResponse> GetById(string userId, int id);
        Task<List<TransactionResponse>> GetAll(string userId);
    }
}
