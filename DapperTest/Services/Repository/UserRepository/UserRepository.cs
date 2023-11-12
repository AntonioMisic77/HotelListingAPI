using BCrypt.Net;
using Dapper;
using DapperTest.Models;
using DapperTest.Services.SQLConnectionFactory;

namespace DapperTest.Services.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<User>> GetUserByEmailAsync(string email)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                SELECT * FROM "User"
                WHERE "User"."email" = @email
             """;

           return  await connection.QueryAsync<User>(sql,new {email = email});
        }

        public async Task CreateUserAsync(User user)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                INSERT INTO "User" ("username","passwordhash","firstname","lastname","email")
                VALUES (@UserName,@passwordHash,@FirstName,@LastName,@email)
             """;

            string password = user.passwordHash;
            user.passwordHash =  BCrypt.Net.BCrypt.HashPassword(password);

            await connection.ExecuteAsync(sql,user);
        }

    }
}
