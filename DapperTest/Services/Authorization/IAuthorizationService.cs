namespace DapperTest.Services.Authorization
{
    public interface IAuthorizationService
    {
        public Task<string> Login(string email, string password);
    }
}
