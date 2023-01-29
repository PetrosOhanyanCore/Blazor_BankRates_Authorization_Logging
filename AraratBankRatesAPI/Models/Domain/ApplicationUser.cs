using Microsoft.AspNetCore.Identity;

namespace AraratBankRatesAPI.Models.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string? Name { get; set; }
    }
}
