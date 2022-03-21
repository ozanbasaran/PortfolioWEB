using System.ComponentModel.DataAnnotations;

namespace PortfolioAPIS.DTOs.Post
{
    public class PostViewModel: BasePostModel
    {
        [Required]
        public int Id { get; set; }
    }
}
