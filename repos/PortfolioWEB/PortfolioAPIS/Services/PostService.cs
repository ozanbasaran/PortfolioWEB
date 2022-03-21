using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PortfolioAPIS.DTOs.Post;
using PortfolioAPIS.Mappers;
using PortfolioAPIS.Model;
using PortfolioAPIS.Validators;
using PortfolioWeb.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioAPIS.Services
{
    public class PostService : IPostService
    {
        private readonly EntityContext _entityContext;

        public PostService(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }
        public IList<PostViewModel> GetPosts()
        {
            var post = from p in _entityContext.Posts
                       select new PostViewModel()
                       {
                           Id = p.Id,
                           Topic = p.Topic,
                           Content = p.Content
                       };
            return post.ToList();
        }

        PostViewModel IPostService.GetPost(int id)
        {
            var post = _entityContext.Posts.First(p => p.Id.Equals(id));
            return post.Map();
        }

        public ServiceResult<PostUpdateModel> Update(PostUpdateModel model)
        {

            var serviceresult = new ServiceResult<PostUpdateModel>();
            //var user= mapper.Map<UserUpdateModel>(model);
            var post = model.Map();
            if (!_entityContext.Posts.Any(u => u.Id == model.Id))
            {
                serviceresult.Http_Code = System.Net.HttpStatusCode.NotFound;
                serviceresult.notFound = true;
                return serviceresult;
            }
            else
            {
                var entity = _entityContext.Posts.FirstOrDefault(p => p.Id == model.Id);
                entity.Topic= post.Topic;
                entity.Content = post.Content;
                _entityContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                try
                {
                    _entityContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }
                serviceresult.data = model;
                serviceresult.Http_Code = System.Net.HttpStatusCode.OK;

                return serviceresult;
            }
        }

        ServiceResult<PostViewModel> IPostService.AddPost(PostCreateModel postPostModel)
        {
            var post = postPostModel.Map();
            var serviceresult = new ServiceResult<PostViewModel>();
            if (!_entityContext.Users.Any(u => u.Id == postPostModel.UserId))
            {
                serviceresult.Http_Code = System.Net.HttpStatusCode.NotFound;
                serviceresult.notFound = true;
                return serviceresult;
            }
            else
            {
                _entityContext.Posts.Add(post);
                _entityContext.SaveChanges();
                serviceresult.data = post.Map();
                serviceresult.Http_Code = System.Net.HttpStatusCode.OK;
                return serviceresult;
            }
        }
        public async Task<int> Delete(int id)
        {
            var post = await _entityContext.Posts.FindAsync(id);
            if (post == null)
            {
                return 1;
            }
            _entityContext.Posts.Remove(post);
            await _entityContext.SaveChangesAsync();
            return 2;
        }


    }
}
