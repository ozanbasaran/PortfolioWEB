
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioAPIS.DTOs.Comment;
using PortfolioAPIS.DTOs.Post;
using PortfolioAPIS.DTOs.Token;
using PortfolioAPIS.DTOs.User;
using PortfolioAPIS.Validators;

namespace PortfolioAPIS.Installers
{

    internal class RegisterModelValidators : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            //Register DTO Validators

            services.AddTransient<IValidator<UserViewModel>, UserViewValidator>();
            services.AddTransient<IValidator<UserUpdateModel>, UserUpdateValidator>();
            services.AddTransient<IValidator<UserCreateModel>, UserCreateValidator>();
            services.AddTransient<IValidator<PostCreateModel>, PostCreateValidator>();
            services.AddTransient<IValidator<PostUpdateModel>, PostUpdateValidator>();
            services.AddTransient<IValidator<PostViewModel>, PostViewValidator>();
            services.AddTransient<IValidator<CommentCreateModel>, CommentCreateValidator>();
            services.AddTransient<IValidator<CommentUpdateModel>, CommentUpdateValidator>();
            services.AddTransient<IValidator<CommentViewModel>, CommentViewValidator>();
            services.AddTransient<IValidator<AuthModel>, AuthModelValidator>();



            //Disable Automatic Model State Validation built-in to ASP.NET Core
            services.Configure<ApiBehaviorOptions>(opt => { opt.SuppressModelStateInvalidFilter = true; });
        }
    }
}

