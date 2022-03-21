using System.ComponentModel.DataAnnotations;

namespace PortfolioAPIS.DTOs.Post
{
    public class PostCreateModel: BasePostModel
    {
        [Required]
        public int UserId { get; set; }
    }
}
