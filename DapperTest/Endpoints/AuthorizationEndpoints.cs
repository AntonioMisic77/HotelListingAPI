using DapperTest.Data.Login;
using DapperTest.Models;
using DapperTest.Services.Authorization;
using System.Runtime.CompilerServices;

namespace DapperTest.Endpoints
{
    public static class AuthorizationEndpoints
    {
        public static void MapAuthorizationEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("authorization");

            group.MapPost("", async (IAuthorizationService service,LoginDto loginDto) =>
            {
                var token = await service.Login(loginDto.email,loginDto.password);

                return token.Length == 0 ? Results.Unauthorized() : Results.Ok(token);
            });
        }
    }
}
