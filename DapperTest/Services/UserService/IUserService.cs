using DapperTest.Models;

namespace DapperTest.Services.UserService
{
    public interface IUserService
    {
        public Task<User?> GetUserByEmail(string email);

        public Task CreateUser(User user);
    }
}
