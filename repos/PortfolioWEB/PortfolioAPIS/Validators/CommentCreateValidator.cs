using FluentValidation;
using PortfolioAPIS.DTOs.Comment;
namespace PortfolioAPIS.Validators
{
    public class CommentCreateValidator : AbstractValidator<CommentCreateModel>
    {
        public CommentCreateValidator()
        {



            RuleFor(c => c.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is empty!")
                .Length(2, 50).WithMessage("Please provide a valid topic");

            RuleFor(c => c.Text)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty().WithMessage("Text is empty")
                        .Length(2, 5000).WithMessage("Please provide a valid content");

        }
    }
}




