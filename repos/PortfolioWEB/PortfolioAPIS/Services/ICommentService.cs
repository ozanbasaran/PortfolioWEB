using PortfolioAPIS.DTOs.Comment;
using PortfolioAPIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioAPIS.Services
{
    public interface ICommentService
    {
        IList<CommentViewModel> GetComments();

        CommentViewModel GetComment(int id);
        public ServiceResult<CommentUpdateModel> Update(CommentUpdateModel model);

        ServiceResult<CommentViewModel> AddComment(CommentCreateModel commentPostModel);

        Task<int> Delete(int id);
    }
}
