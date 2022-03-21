using PortfolioAPIS.DTOs.User;
using PortfolioAPIS.Model;
using PortfolioWeb.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioAPIS.Services
{
    public interface IUserService
    {
        IList<UserViewModel> GetUsers();
        UserViewModel GetUser(int id);
        public ServiceResult<UserUpdateModel> Update(UserUpdateModel model);

        ServiceResult<UserViewModel> AddUser(UserCreateModel userPostModel);

        Task<int> Delete(int id);
    }
}
