using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PortfolioAPIS.DTOs.Comment;
using PortfolioAPIS.Mappers;
using PortfolioAPIS.Model;
using PortfolioAPIS.Validators;
using PortfolioWeb.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioAPIS.Services
{
    public class CommentService : ICommentService
    {
        private readonly EntityContext _entityContext;

        public CommentService(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }
        public IList<CommentViewModel> GetComments()
        {
            var comment = from c in _entityContext.Comments
                          select new CommentViewModel()
                          {
                              Id = c.ID,
                              Text = c.Text,
                              Title = c.Title
                          };
            return comment.ToList();
        }

        public CommentViewModel GetComment(int id)
        {
            var comment = _entityContext.Comments.First(p => p.ID.Equals(id));
            return comment.Map();
        }
        public ServiceResult<CommentUpdateModel> Update(CommentUpdateModel model)
        {
            var serviceresult = new ServiceResult<CommentUpdateModel>();
            var comment = model.Map();
            if (!_entityContext.Comments.Any(u => u.ID == model.Id))
            {
                serviceresult.Http_Code = System.Net.HttpStatusCode.NotFound;
                serviceresult.notFound = true;
                return serviceresult;
            }
            else
            {
                _entityContext.Entry(comment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        ServiceResult<CommentViewModel> ICommentService.AddComment(CommentCreateModel commentPostModel)
        {
            var comment = commentPostModel.Map();
            var serviceresult = new ServiceResult<CommentViewModel>();
            if (!_entityContext.Users.Any(u => u.Id == commentPostModel.UserID))
            {
                serviceresult.Http_Code = System.Net.HttpStatusCode.NotFound;
                serviceresult.notFound = true;
                return serviceresult;
            }
            if (!_entityContext.Posts.Any(u => u.Id == commentPostModel.PostID))
            {
                serviceresult.Http_Code = System.Net.HttpStatusCode.NotFound;
                serviceresult.notFound = true;
                return serviceresult;
            }
            else
            {
                _entityContext.Comments.Add(comment);
                _entityContext.SaveChanges();
                serviceresult.data = comment.Map();
                serviceresult.Http_Code = System.Net.HttpStatusCode.OK;
                return serviceresult;
            }
        }
        public async Task<int> Delete(int id)
        {
            var comment = await _entityContext.Comments.FindAsync(id);
            if (comment == null)
            {
                return 1;
            }
            _entityContext.Comments.Remove(comment);
            await _entityContext.SaveChangesAsync();
            return 2;
        }





    }
}
