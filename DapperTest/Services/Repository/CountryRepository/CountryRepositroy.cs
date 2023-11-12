using Dapper;
using DapperTest.Models;
using DapperTest.Services.SQLConnectionFactory;

namespace DapperTest.Services.Repository.CountryRepository
{
    public class CountryRepositroy : ICountryRepository
    {
        private ISqlConnectionFactory _connectionFactory;

        public CountryRepositroy(ISqlConnectionFactory factory)
        {
                _connectionFactory = factory;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {

            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    SELECT *
                    FROM "Countries";
                """;

            return await connection.QueryAsync<Country>(sql);
        }

        public async Task<IEnumerable<Country>> GetCountryAsync(int id)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    SELECT *
                    FROM "Countries"
                    WHERE "Id" = @Id;
                """;

            return await connection.QueryAsync<Country>(sql, new { Id = id });
        }

        public async Task CreateCountryAsync(Country country)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    INSERT INTO "Countries" ("Name","ShortName")
                    VALUES (@Name,@ShortName)
                """;

            await connection.ExecuteAsync(sql, country);
        }

        public async Task UpdateCountryAsync(Country country)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    UPDATE "Countries"
                    SET ("Name","ShortName") = ROW(@Name,@ShortName)
                    WHERE "Id" = @Id
                """;

            await connection.ExecuteAsync(sql, new { Name = country.Name, ShortName = country.ShortName, Id = country.Id });
        }

        public async Task DeleteCountryAsync(int id)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    DELETE FROM "Countries"
                    WHERE "Id" = @Id
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
