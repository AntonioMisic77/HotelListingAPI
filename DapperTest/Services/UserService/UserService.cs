using DapperTest.Models;
using DapperTest.Services.Repository.UserRepository;

namespace DapperTest.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

    
        public async Task<User?> GetUserByEmail(string email)
        {
            var users = await _userRepository.GetUserByEmailAsync(email);

            return users.Count() > 0 ? users.First() : null;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.CreateUserAsync(user);
        }
    }
}
