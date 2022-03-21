using Microsoft.AspNetCore.Mvc;
using PortfolioAPIS.DTOs.User;
using PortfolioAPIS.Model;
using PortfolioAPIS.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PortfolioAPIS.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        
        
        [Authorize]
        [HttpGet]
        [Route("get_users")]
        
        public IList<UserViewModel> GetUsers()
        {
            var users = _userService.GetUsers();
            return users;
        }

        [HttpGet]
        [Route("get_user/{id}")]
        
        public async Task<ActionResult> GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound(); //Implicitly casted the return type ask if it's ok
            }
            return Ok(user);
        }


        [HttpPut]
        [Route("update_user/{id}")]
        public ServiceResult<UserUpdateModel> PutUser(UserUpdateModel model)
        {
            var result = new ServiceResult<UserUpdateModel>();
            if (!ModelState.IsValid)
            {
                result.errorList = ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
                result.Http_Code = System.Net.HttpStatusCode.BadRequest;
            }
            else
            {
                result = _userService.Update(model);
                if (result.notFound == true)
                {
                    result.errorList = new List<string>();
                    result.errorList.Add("UserId Not Found");
                }
            }
            return result;
        }
        [HttpPost]
        [Route("add_user")]
        public ServiceResult<UserViewModel> PostUser(UserCreateModel userPostModel)
        {
            var result = new ServiceResult<UserViewModel>();
            if (!ModelState.IsValid)
            {
                result.Http_Code = System.Net.HttpStatusCode.BadRequest;
                result.errorList = ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
            }
            else
            {
                result = _userService.AddUser(userPostModel);
            }
            return result;

        }

        [HttpDelete]
        [Route("delete_user/{id}")]
        public async Task<ActionResult<UserViewModel>> DeleteUser(int id)
        {
            var result = _userService.Delete(id);
            if (result.Result == 1) return NotFound();
            else return Ok();
            //return new NoContentResult();
        }


    }
}
