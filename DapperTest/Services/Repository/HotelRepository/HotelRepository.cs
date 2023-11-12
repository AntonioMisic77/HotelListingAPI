using Dapper;
using DapperTest.Models;
using DapperTest.Services.SQLConnectionFactory;

namespace DapperTest.Services.Repository.HotelRepository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public HotelRepository(ISqlConnectionFactory factory)
        { 
            _connectionFactory = factory;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync()
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    SELECT h.*,
                           c."Name" as Name,
                           c."ShortName" as ShortName
                    FROM "Hotels" as h
                    JOIN "Countries" as c on h."CountryId" = c."Id"
                """;

            var hotels = await connection.QueryAsync<Hotel, Country, Hotel>(
                sql,
                (hotel, country) =>
                {
                    hotel.country = country;
                    return hotel;
                }
                 ,
                splitOn: "CountryId");

            return hotels;
        }

        public async Task<IEnumerable<Hotel>> GetHotelAsync(int id)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    SELECT h.*,
                           c."Name" as Name,
                           c."ShortName" as ShortName
                    FROM "Hotels" as h
                    JOIN "Countries" as c on h."CountryId" = c."Id"
                    WHERE h."Id" = @Id
                """;

            var hotel = await connection.QueryAsync<Hotel, Country, Hotel>(
                sql,
                (hotel, country) =>
                {
                    hotel.country = country;
                    return hotel;
                },
                new
                {
                    Id = id
                }
                ,
                splitOn: "CountryId");

            return hotel;
        }

        public async Task CreateHotelAsync(Hotel hotel)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    INSERT INTO "Hotels" ("Name","Adress","Rating","CountryId")
                    VALUES (@Name,@Adress,@Rating,@CountryId)
                """;

            await connection.ExecuteAsync(sql, hotel);

        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    UPDATE "Hotels"
                        SET ("Name","Adress","Rating","CountryId") = ROW(@Name,@Adress,@Rating,@CountryId)
                    WHERE "Id" = @Id
                """;

            await connection.ExecuteAsync(sql, hotel);
        }

        public async Task DeleteHotelAsync(int id)
        {
            using var connection = _connectionFactory.GetNpgsqlConnection("ExampleConnectionString");

            string sql = """
                    DELETE FROM "Hotels" as h
                    WHERE h."Id" = @Id
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
