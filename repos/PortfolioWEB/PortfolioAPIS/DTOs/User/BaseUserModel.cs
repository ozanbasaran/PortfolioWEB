namespace PortfolioAPIS.DTOs.User
{
    public abstract class BaseUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
