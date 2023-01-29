using AraratBankRatesAPI.Models.DTO;
using System.Security.Claims;

namespace AraratBankRatesAPI.Repositories.Abstract

{
    public interface ITokenService
    {
        TokenResponse GetToken(IEnumerable<Claim> claim);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
