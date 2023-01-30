using AraratBankRates.Models;

namespace AraratBankRates.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> Login(LoginDTO model);
        Task Logout();
        Task<RegisterResponse> Register(RegisterDTO model);
    }
}