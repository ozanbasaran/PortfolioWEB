using Microsoft.AspNetCore.Mvc;
using PortfolioAPIS.DTOs.Post;
using PortfolioAPIS.Model;
using PortfolioAPIS.Services;
using System.Collections.Generic;
using System.Linq;
using Authorize = Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PortfolioAPIS.Controllers
{
    [Authorize(Roles = "*")]
    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get_posts")]
        public IList<PostViewModel> GetPosts()
        {
            var posts = _postService.GetPosts();
            return posts;
        }
        [HttpGet]
        [Route("get_post/{id}")]

        public async Task<ActionResult> GetPost(int id)
        {
            
            var post = _postService.GetPost(id);
            if (post == null)
            {
                return NotFound(); //Implicitly casted the return type ask if it's ok
            }
            return Ok(post);
        }


        [HttpPut("{id}")]
        [Route("update_post")]
        public ServiceResult<PostUpdateModel> PutPost(PostUpdateModel model)
        {
            var result = new ServiceResult<PostUpdateModel>();
            if (!ModelState.IsValid)
            {
                result.Http_Code = System.Net.HttpStatusCode.BadRequest;
                result.errorList = ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
            }
            else
            {
                result = _postService.Update(model);
                if (result.notFound == true)
                {
                    result.errorList = new List<string>();
                    result.errorList.Add("PostId Not Found");
                }
            }

            return result;
        }

        [HttpPost]
        [Route("add_post")]
        public ServiceResult<PostViewModel> PostPost(PostCreateModel postPostModel)
        {
            var result = new ServiceResult<PostViewModel>();
            if (!ModelState.IsValid)
            {
                result.Http_Code = System.Net.HttpStatusCode.BadRequest;
                result.errorList = ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
            }
            else
            {
                result = _postService.AddPost(postPostModel);
                if (result.notFound == true)
                {
                    result.errorList = new List<string>();
                    result.errorList.Add("A non existing author can not do this I suppose");
                }

            }
            return result;

        }


        [HttpDelete]
        [Route("delete_post/{id}")]
        public async Task<ActionResult<PostViewModel>> DeletePost(int id)
        {
            var result = _postService.Delete(id);
            if (result.Result == 1) return NotFound();
            else return Ok();
        }
       
    }
}
