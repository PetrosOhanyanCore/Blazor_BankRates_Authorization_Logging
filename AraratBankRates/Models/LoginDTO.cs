using System.ComponentModel.DataAnnotations;

namespace AraratBankRates.Models
{
    public class LoginDTO
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
