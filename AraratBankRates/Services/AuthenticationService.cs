using AraratBankRates.AuthProviders;
using AraratBankRates.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace AraratBankRates.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly string _baseUrl;

        public AuthenticationService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _baseUrl = "https://localhost:7163/api/authorization";
        }

        public async Task<LoginResponse> Login(LoginDTO model)
        {
            var loginResult = await _httpClient.PostAsJsonAsync($"{_baseUrl}/login", model);
            if (!loginResult.IsSuccessStatusCode)
            {
                return new LoginResponse
                { 
                    StatusCode = 0,
                    Message = "Server error" 
                };
            }
            var loginResponseContent = await loginResult.Content.ReadFromJsonAsync<LoginResponse>();
            if (loginResponseContent != null)
            {
                _localStorage.SetItemAsync("accessToken", loginResponseContent.Token);
                ((AuthProvider)_authStateProvider).NotifyUserAuthentication(loginResponseContent.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponseContent.Token);
            }
            return loginResponseContent;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("accessToken");
            ((AuthProvider)_authStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterResponse> Register(RegisterDTO model)
        {
            var registerResult = await _httpClient.PostAsJsonAsync($"{_baseUrl}/registration", model);
            if (!registerResult.IsSuccessStatusCode)
            {
                return new RegisterResponse
                {
                    Status = 0,
                    Message = "Server error"
                };
            }
            else
            {
                return new RegisterResponse
                {
                    Status = 1,
                    Message = "Success"
                };
            }
        }
    }
}
