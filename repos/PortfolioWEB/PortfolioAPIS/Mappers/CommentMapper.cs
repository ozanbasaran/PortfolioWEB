using PortfolioAPIS.DTOs.Comment;
using PortfolioWeb.Data;

namespace PortfolioAPIS.Mappers
{
    public static class CommentMapper
    {
        public static Comment Map(this CommentCreateModel model)
        {
            var Comment = new Comment
            {
                Title = model.Title,
                Text = model.Text,
                PostID = model.PostID,
                UserID = model.UserID
            };
            return Comment;
        }

        public static Comment Map(this CommentUpdateModel model)
        {
            var Comment = new Comment
            {
                ID = model.Id,

                Title = model.Title,
                Text = model.Text
            };
            return Comment;
        }
        public static CommentViewModel  Map(this Comment model)
        {
            var viewModel = new CommentViewModel
            {
                Id = model.ID,
                Title = model.Title,
                Text = model.Text,
            };
            return viewModel;
        }
        public static CommentViewModel MapforValidate(this CommentUpdateModel model)
        {
            var viewModel = new CommentViewModel
            {
                Id = model.Id,
                Text = model.Text,
                Title = model.Title
            };
            return viewModel;
        }
        public static CommentViewModel MapforValidate(this Comment model)
        {
            var viewModel = new CommentViewModel
            {
                Id = model.ID,
                Text = model.Text,
                Title = model.Title
            };
            return viewModel;
        }
    }
}
