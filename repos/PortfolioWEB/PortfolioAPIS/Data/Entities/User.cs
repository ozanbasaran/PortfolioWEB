using PortfolioWeb.Data.Enums;
using System;
using System.Collections.Generic;

namespace PortfolioWeb.Data
{
    public class User: Entity
    {
       public User() { }
        public int Id { get; set; }
        public string UserName { get; set; }
        private string _PassWord;

        public User(string userName, string passWord, string firstName, string lastName)
        {
            UserName = userName;
            PassWord = passWord;
            FirstName = firstName;
            LastName = lastName;
            Posts= new List<Post>();
            Comments= new List<Comment>();
            CreatedDate= DateTime.Now;

        }

        public string PassWord
        {
            get { return _PassWord; }
            set { _PassWord = value; }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Post> Posts { get; set; }

        public IList<Comment> Comments { get; set; }

        

            

        public TimeSpan MemberFor
        {
            get
            {
                return this.Difference();
            }
        }


        public override bool Validate()
        {
            var IsValid = true;
            if (string.IsNullOrWhiteSpace(FirstName)) IsValid = false;
            if (string.IsNullOrWhiteSpace(LastName)) IsValid = false;
            if (string.IsNullOrWhiteSpace(PassWord)) IsValid = false;
            if (string.IsNullOrWhiteSpace(UserName)) IsValid = false;
            return IsValid;
        }

        public UserRoleEnum Role;


    }
}
