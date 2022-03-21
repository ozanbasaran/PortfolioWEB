using System.ComponentModel.DataAnnotations;

namespace PortfolioAPIS.DTOs.Comment
{
    public class CommentCreateModel: BaseCommentModel
    {
        [Required]
        public int PostID { get; set; }
        [Required]
        public int UserID { get; set; }

    }
}
