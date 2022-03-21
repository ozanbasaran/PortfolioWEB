using System.ComponentModel.DataAnnotations;

namespace PortfolioAPIS.DTOs.Comment
{
    public class CommentViewModel: BaseCommentModel
    {
        [Required]
        public int Id { get; set; }
    }
}
