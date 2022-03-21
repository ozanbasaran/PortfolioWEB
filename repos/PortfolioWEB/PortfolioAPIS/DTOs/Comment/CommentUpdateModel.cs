using System.ComponentModel.DataAnnotations;

namespace PortfolioAPIS.DTOs.Comment
{
    public class CommentUpdateModel:BaseCommentModel
    {
        [Required]
        public int Id { get; set; }
    }
}
