using PortfolioAPIS.DTOs.User;
using PortfolioWeb.Data;

namespace PortfolioAPIS.Mappers
{
    public static class UserMapper
    {
        public static User Map(this UserCreateModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PassWord = model.Password
            };
            return user;
        }

        public static User Map(this UserUpdateModel model)
        {
            var user = new User
            { 
                Id = model.Id,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PassWord = model.Password
            };
            return user;
        }
        public static UserViewModel Map(this User model)
        {
            var viewModel = new UserViewModel
            {
                Id = model.Id,
                UserName = model.UserName,
                Password = model.PassWord,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            return viewModel;
        }
        
        public static UserViewModel MapforValidate(this UserUpdateModel model)
        {
            var viewModel = new UserViewModel
            {
                Id = model.Id,
                UserName = model.UserName,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            return viewModel;
        }
        public static UserViewModel MapforValidate(this User model)
        {
            var viewModel = new UserViewModel
            {
                Id = model.Id,
                UserName = model.UserName,
                Password = model.PassWord,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            return viewModel;
        }

    }
}
