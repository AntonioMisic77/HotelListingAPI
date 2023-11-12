using Dapper;
using DapperTest.Models;
using DapperTest.Services.SQLConnectionFactory;
using NpgsqlTypes;
using System.Runtime.CompilerServices;

namespace DapperTest.Endpoints
{
    public static class CordEndpoints
    {
        public static  void MapCordEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("cord", (ISqlConnectionFactory factory) =>
            {

                using var connection = factory.GetNpgsqlConnection("DefaultConnectionString");

                string sql = """
                    SELECT id,cord_uid,title
                    from cord19;
                """;

                var cord = connection.Query<Cord>(sql);

                return Results.Ok(cord);
            });


            builder.MapGet("cord/{id}", (ISqlConnectionFactory factory, int id) =>
            {

                using var connection = factory.GetNpgsqlConnection("DefaultConnectionString");

                string sql = """
        SELECT id,cord_uid,title
            from cord19
            where id = @id;
    """;

                var cord = connection.Query<Cord>(sql, new { id = id });

                return Results.Ok(cord);
            });

            builder.MapPost("cord", async (ISqlConnectionFactory factory, Cord cord) =>
            {

                using var connection = factory.GetNpgsqlConnection("DefaultConnectionString");

                string sql = """
        INSERT INTO cord19 (cord_uid,title,abstract,allTSV)
        VALUES (@cord_uid,@title,@Abstract,@allTSV)
    """;

                await connection.ExecuteAsync(sql, new
                {
                    cord_uid = cord.cord_uid,
                    title = cord.title,
                    Abstract = "",
                    allTSV = NpgsqlTsVector.Parse("")
                });

                return Results.Ok();
            });

            builder.MapPut("cord", async (ISqlConnectionFactory factory, Cord cord) =>
            {
                using var connection = factory.GetNpgsqlConnection("DefaultConnectionString");

                string sql = """
        UPDATE cord19
        SET title = @title
        where id = @id
    """;

                await connection.ExecuteAsync(sql, new { id = cord.Id, title = cord.title });

                return Results.Ok();
            });

            builder.MapDelete("cord/{id}", async (ISqlConnectionFactory factory, int id) =>
            {
                using var connection = factory.GetNpgsqlConnection("DefaultConnectionString");

                string sql = """
        DELETE FROM cord19
        WHERE id = @id
    """;

                await connection.ExecuteAsync(sql, new { id = id });

                return Results.Ok();
            });
        }
    }
}
