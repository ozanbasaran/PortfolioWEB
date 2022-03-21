namespace Portfolio__Ozan_BASARAN.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }    
        private string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }
    }
}
