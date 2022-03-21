using PortfolioAPIS.DTOs.Post;
using PortfolioWeb.Data;

namespace PortfolioAPIS.Mappers
{
    public static class PostMapper
    {
        public static Post Map(this PostCreateModel model)
        {
            var post = new Post
            {
                Content = model.Content,
                Topic = model.Topic,
                UserId = model.UserId
            };
            return post;
        }

        public static Post Map(this PostUpdateModel model)
        {
            var post = new Post
            {
                Id = model.Id,
                Content = model.Content,
                Topic = model.Topic
            };
            return post;
        }
        public static PostViewModel Map(this Post model)
        {
            var viewModel = new PostViewModel
            {
                Id = model.Id,
                Content = model.Content,
                Topic = model.Topic,
            };
            return viewModel;
        }
        public static PostViewModel MapforValidate(this PostUpdateModel model)
        {
            var viewModel = new PostViewModel
            {
                Id = model.Id,
                Topic = model.Topic,
                Content=model.Content
            };
            return viewModel;
        }
        public static PostViewModel MapforValidate(this Post model)
        {
            var viewModel = new PostViewModel
            {
                Id = model.Id,
                Topic = model.Topic,
                Content = model.Content
            };
            return viewModel;
        }
    }
}
