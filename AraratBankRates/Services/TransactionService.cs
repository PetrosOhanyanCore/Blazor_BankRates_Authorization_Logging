using AraratBankRates.Models;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AraratBankRates.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly ILocalStorageService _localStorage;

        public TransactionService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorage = localStorageService;
            _baseUrl = "https://localhost:7163/api/transactions";
        }

        public async Task<double> Calculate(Calculate calculate)
        {
            var token = await _localStorage.GetItemAsync<string>("accessToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));
            var res = await _httpClient.PostAsJsonAsync($"{_baseUrl}/calculate", calculate);
            var response = await res.Content.ReadFromJsonAsync<double>();

            return response;
        }

        public async Task CreateTransaction(TransactionRequest model)
        {
            await _httpClient.PostAsJsonAsync($"{_baseUrl}/create", model);
        }

        public async Task<List<TransactionResponse>> GetAll()
        {
            var result = await _httpClient.SendAsync(new HttpRequestMessage
            {

                Method = HttpMethod.Get,

                RequestUri = new Uri($"{_baseUrl}/list")
            });

            result.EnsureSuccessStatusCode();

            var responseBody = await result.Content.ReadAsStringAsync();

            var transactionResponse = JsonSerializer.Deserialize<List<TransactionResponse>?>(responseBody);

            return transactionResponse;
        }

        public async Task<TransactionResponse> GetById(int id)
        {
            var result = await _httpClient.GetAsync($"{_baseUrl}/getById?id={id}");

            var responseBody = await result.Content.ReadAsStringAsync();

            TransactionResponse? transactionResponse =
                JsonSerializer.Deserialize<TransactionResponse>(responseBody);

            return transactionResponse;
        }
    }
}
