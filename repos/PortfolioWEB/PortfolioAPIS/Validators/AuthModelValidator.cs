using FluentValidation;
using PortfolioAPIS.DTOs.Token;

namespace PortfolioAPIS.Validators
{
    public class AuthModelValidator: AbstractValidator<AuthModel>
    {
        public AuthModelValidator()
        {
            RuleFor(u => u.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is empty")
                .Length(2, 50).WithMessage("Please provide a valid username");


            RuleFor(u => u.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password is empty")
                .Length(8, 50).WithMessage("Password must at least be 8 characters long.")
                .Must(ValidPassword).WithMessage("Please re-enter your password following below mentoned guidelines!");
        }
        protected bool ValidPassword(string pass)
        {
            int count = 0;
            foreach (char c in pass)
            {
                if (c >= 65 && c <= 90)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return false; //Assert there exists 1 uppercase letter
            }
            int coun = 0;
            foreach (char c in pass)
            {
                if (c >= 48 && c <= 57)
                {
                    coun++;
                }
            }
            if (coun == 0)
            {
                return false; //Assert there exists 1 number
            }
            else
            {
                return true;
            }
        }
    }
}
