using DapperTest.Models;

namespace DapperTest.Services.Repository.UserRepository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUserByEmailAsync(string email);

        public Task CreateUserAsync(User user);
    }
}
