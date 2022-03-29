using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PortfolioAPIS.DTOs.Comment;
using PortfolioAPIS.Model;
using PortfolioAPIS.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioAPIS.Controllers
{
    [Authorize(Roles = "*")]
    [Route("api/[controller]")]
    [ApiController]

    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("get_comments")]
        public IList<CommentViewModel> GetComments()
        {
            var comments = _commentService.GetComments();
            return comments;
        }




        [HttpGet]
        [Route("get_comment/{id}")]

        public async Task<ActionResult> GetComment(int id)
        {
            var comment = _commentService.GetComment(id);
            if (comment == null)
            {
                return NotFound(); //Implicitly casted the return type ask if it's ok
            }
            return Ok(comment);
        }

        [HttpPut("{id}")]
        [Route("update_comment")]
        public ServiceResult<CommentUpdateModel> PutComment(CommentUpdateModel model)
        {
            var result = new ServiceResult<CommentUpdateModel>();
            if (!ModelState.IsValid)
            {
                result.Http_Code = System.Net.HttpStatusCode.BadRequest;
                result.errorList = ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
            }
            else
            {
                result = _commentService.Update(model);
                if (result.notFound == true)
                {
                    result.errorList = new List<string>();
                    result.errorList.Add("CommentId Not Found");
                }
            }

            return result;
        }
        [HttpPost]
        [Route("add_comment")]
        public ServiceResult<CommentViewModel> PostComment(CommentCreateModel commentPostModel)
        {
            var result = new ServiceResult<CommentViewModel>();
            if (!ModelState.IsValid)
            {
                result.Http_Code = System.Net.HttpStatusCode.BadRequest;
                result.errorList = ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
            }
            else
            {
                result = _commentService.AddComment(commentPostModel);
                if(result.notFound == true)
                {
                    result.errorList= new List<string>();
                    result.errorList.Add("Yo, either you are not authoried or post is deleted :(");
                }
            }
            return result;

        }


        [HttpDelete]
        [Route("delete_comment/{id}")]
        public async Task<ActionResult<CommentViewModel>> DeleteComment(int id)
        {
            var result = _commentService.Delete(id);
            if (result.Result == 1) return NotFound();
            return Ok();
        }


       
    }
}
