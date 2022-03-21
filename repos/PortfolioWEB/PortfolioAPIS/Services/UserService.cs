using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortfolioAPIS.DTOs.User;
using PortfolioAPIS.Mappers;
using PortfolioAPIS.Model;
using PortfolioAPIS.Validators;
using PortfolioWeb.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioAPIS.Services
{
    public class UserService : IUserService
    {
        public IMapper mapper { get; set; }

        private readonly EntityContext _entityContext;

        public UserService(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }
        public IList<UserViewModel> GetUsers()
        {
            var user = from u in _entityContext.Users
                       select new UserViewModel()
                       {
                           Id = u.Id,
                           UserName = u.UserName,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Password = u.PassWord
                       };
            return user.ToList();
        }
        

        
        UserViewModel IUserService.GetUser(int id)
        {
            var user = _entityContext.Users.First(p => p.Id.Equals(id));
            //return mapper.Map<UserViewModel>(user);
            return user.Map();
        }

        public ServiceResult<UserUpdateModel> Update(UserUpdateModel model)
        {

            var serviceresult = new ServiceResult<UserUpdateModel>();


            //var user= mapper.Map<UserUpdateModel>(model);
            var user = model.Map();
            if (!_entityContext.Users.Any(u => u.Id == model.Id))
            {
                serviceresult.Http_Code = System.Net.HttpStatusCode.NotFound;
                serviceresult.notFound=true;
                return serviceresult;
            }
            else
            {
                _entityContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        ServiceResult<UserViewModel> IUserService.AddUser(UserCreateModel userPostModel)
        {
            var user = userPostModel.Map();
            var serviceresult = new ServiceResult<UserViewModel>();


            _entityContext.Users.Add(user);
            _entityContext.SaveChanges();
            serviceresult.data = user.Map();
            serviceresult.Http_Code = System.Net.HttpStatusCode.OK;
            return serviceresult;

        }
        public async Task<int> Delete(int id)
        {
            var user = await _entityContext.Users.FindAsync(id);
            if (user == null)
            {
                return 1;
            }
            _entityContext.Users.Remove(user);
            await _entityContext.SaveChangesAsync();
            return 2;
        }
    }
}

