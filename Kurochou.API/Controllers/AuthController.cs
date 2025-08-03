using Kurochou.API.Helpers;
using Kurochou.Domain.DTO.Auth;
using Kurochou.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kurochou.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthenticationService service) : ControllerBase
{
        [HttpPost("Register")]
        public async Task<IResult> RegisterAsync([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
                var result = await service.Register(request, cancellationToken);

                if (result is null)
                        return ApiResult.Failure("Unable to register the user");

                return ApiResult.Success(result, "Registered in successfully");
        }

        [HttpPost("Login")]
        public async Task<IResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
                var result = await service.Login(request, cancellationToken);

                if (result is null || string.IsNullOrWhiteSpace(result.Token))
                        return ApiResult.Failure("Invalid credentials", 401);

                return ApiResult.Success(result, "Logged in successfully");
        }
}
