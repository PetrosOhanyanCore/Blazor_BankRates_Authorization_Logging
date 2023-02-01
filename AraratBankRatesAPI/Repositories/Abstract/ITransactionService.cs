using AraratBankRatesAPI.Models.DTO;

namespace AraratBankRatesAPI.Repositories.Abstract
{
    public interface ITransactionService
    {
        Task Create(TransactionRequest request);
        Task<TransactionResponse> GetById(string userId, int id);
        Task<List<TransactionResponse>> GetAll(string userId);
        Task<RateModel> GetRates();
        Task<double> Calculate(double givenAmount, string givenExchangeType, string receivenExchangeType, RateModel rateModel);
    }
}
