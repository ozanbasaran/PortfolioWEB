using System.ComponentModel.DataAnnotations;

namespace PortfolioAPIS.DTOs.User
{
    public class UserUpdateModel : BaseUserModel
    {
        [Required]
        public int Id { get; set; }
       
    }
}
