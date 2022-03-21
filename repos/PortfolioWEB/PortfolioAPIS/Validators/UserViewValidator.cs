using FluentValidation;
using PortfolioAPIS.DTOs.User;
using System.Linq;


namespace PortfolioAPIS.Validators
{
    public class UserViewValidator: AbstractValidator<UserViewModel>
    {
        public UserViewValidator()
        {
            RuleFor(u => u.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First Name is empty!")
                .Length(2, 50).WithMessage("Please provide a valid first name")
                .Must(ValidName).WithMessage("First Name contains invalid characters");

            RuleFor(u => u.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is empty")
                .Length(2, 50).WithMessage("Please provide a valid last name")
                .Must(ValidName).WithMessage("First Name contains invalid characters");

            RuleFor(u => u.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is empty")
                .Length(2, 50).WithMessage("Please provide a valid username");
                

            RuleFor(u => u.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password is empty")
                .Length(8,50).WithMessage("Password must at least be 8 characters long.")
                .Must(ValidPassword).WithMessage("Please re-enter your password following below mentoned guidelines!");

        }

        protected bool ValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(char.IsLetter);
        }

        protected bool ValidPassword(string pass)
        {
            int count = 0;
            foreach (char c in pass)
            {
                if (c >= 65 && c <=90)
                {
                    count++;
                }
            }
            if(count == 0)
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
