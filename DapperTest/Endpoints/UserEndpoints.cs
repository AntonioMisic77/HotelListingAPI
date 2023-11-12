using DapperTest.Models;
using DapperTest.Services.UserService;
using Microsoft.AspNetCore.Http;

namespace DapperTest.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("user");

            group.MapPost("", async (IUserService userService,User user) =>
            {
                await userService.CreateUser(user);

                return Results.Ok();
            });
        }
    }
}
