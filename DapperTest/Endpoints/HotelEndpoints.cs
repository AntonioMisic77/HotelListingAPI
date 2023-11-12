using Dapper;
using DapperTest.Models;
using DapperTest.Services.HotelService;
using DapperTest.Services.SQLConnectionFactory;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace DapperTest.Endpoints
{
    public static class HotelEndpoints
    {
        public static void MapHotelEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("hotel");

            group.RequireAuthorization();

            group.MapGet("", async (IHotelService service) =>
            {
                var hotels = await service.GetHotelsAsync();

                return hotels.Count() > 0 ? Results.Ok(hotels) : Results.NoContent();
            });

            group.MapGet("{id}", async (IHotelService service,int id) =>
            {
                var hotel = await service.GetHotelAsync(id);

                return hotel != null ? Results.Ok(hotel) : Results.NotFound();
            });

            group.MapPost("", async (IHotelService service,Hotel hotel) =>
            {
                await service.CreateHotelAsync(hotel);

                return Results.Ok();
            });

            group.MapPut("", async (IHotelService service,Hotel hotel) =>
            {
                await service.UpdateHotelAsync(hotel);

                return Results.Ok();
            });

            group.MapDelete("{id}", async (IHotelService service, int id) =>
            {
                await service.DeleteHotelAsync(id);

                return Results.Ok();
            });

        }
    }
}
