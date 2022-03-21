using System.ComponentModel.DataAnnotations;

namespace PortfolioAPIS.DTOs.Token
{
    public class AuthModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
