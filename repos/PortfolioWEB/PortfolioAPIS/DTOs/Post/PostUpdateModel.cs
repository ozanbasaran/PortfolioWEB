using System.ComponentModel.DataAnnotations;

namespace PortfolioAPIS.DTOs.Post
{
    public class PostUpdateModel: BasePostModel
    {
        [Required]
        public int Id { get; set; }
    }
}
