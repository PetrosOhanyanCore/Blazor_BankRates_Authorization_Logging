using System.ComponentModel.DataAnnotations;

namespace AraratBankRatesTest.Models
{
    public class LoginDTO
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
