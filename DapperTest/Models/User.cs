namespace DapperTest.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? email { get; set; }

        public string UserName { get; set; }

        public string passwordHash { get; set; }

    }   
}
