using FluentValidation;
using PortfolioAPIS.DTOs.Post;

namespace PortfolioAPIS.Validators
{
    public class PostUpdateValidator : AbstractValidator<PostUpdateModel>
    {
        public PostUpdateValidator()
        {
            RuleFor(p => p.Topic)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Topic is empty!")
                .Length(2, 50).WithMessage("Please provide a valid topic");

            RuleFor(p => p.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content is empty")
                .Length(2, 5000).WithMessage("Please provide a valid content");


        }

    }
}
