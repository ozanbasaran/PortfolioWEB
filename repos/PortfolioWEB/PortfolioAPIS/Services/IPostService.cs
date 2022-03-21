using PortfolioAPIS.DTOs.Post;
using PortfolioAPIS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioAPIS.Services
{
    public interface IPostService
    {
        IList<PostViewModel> GetPosts();

        PostViewModel GetPost(int id);
        public ServiceResult<PostUpdateModel> Update(PostUpdateModel model);

        ServiceResult<PostViewModel> AddPost(PostCreateModel postPostModel);

        Task<int> Delete(int id);
    }
}
