using Dapper;
using DapperTest.Models;
using DapperTest.Services.CountryService;
using DapperTest.Services.SQLConnectionFactory;

namespace DapperTest.Endpoints
{
    public static class CountryEndpoint
    {
        public static void MapCountryEndpoint(this IEndpointRouteBuilder build)
        {
            var group = build.MapGroup("country");

            group.RequireAuthorization();

            group.MapGet("", async (ICountryService service) =>
            {
                var countries = await service.GetCountriesAsync();

                return countries.Count() > 0 ? Results.Ok(countries) : Results.NoContent(); 
            });


            group.MapGet("{id}", async (ICountryService service,int id) =>
            {
                var country = await service.GetCountry(id);

                return country != null ? Results.Ok(country) : Results.NotFound();

            });

            group.MapPost("", async (ICountryService service, Country country) =>
            {
                await service.CreateCountry(country);

                return Results.Ok();
            });

            group.MapPut("", async (ICountryService service,Country country) =>
            {
               await service.UpdateCountry(country);

               return Results.Ok();
            });

            group.MapDelete("{id}", async (ICountryService service,int id) =>
            {
                await service.DeleteCountry(id);

                return Results.Ok();
            });
        }
    }
}
