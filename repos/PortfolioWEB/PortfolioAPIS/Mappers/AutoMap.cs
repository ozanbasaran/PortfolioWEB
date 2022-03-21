using AutoMapper;
using PortfolioAPIS.DTOs.Comment;
using PortfolioAPIS.DTOs.Post;
using PortfolioAPIS.DTOs.User;
using PortfolioWeb.Data;

namespace PortfolioAPIS.Mappers
{
    public class AutoMap: Profile
    {
        public AutoMap()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User,UserCreateModel>().ReverseMap();
            CreateMap<User, UserUpdateModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Comment, CommentCreateModel>().ReverseMap();
            CreateMap<Comment, CommentUpdateModel>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Post, PostCreateModel>().ReverseMap();
            CreateMap<Post, PostUpdateModel>().ReverseMap();
          





        }
    }
}
