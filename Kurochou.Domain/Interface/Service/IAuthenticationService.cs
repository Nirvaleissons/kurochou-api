using Kurochou.Domain.DTO.Auth;
using Kurochou.Domain.DTO.Auth.Response;

namespace Kurochou.Domain.Interface.Service;

public interface IAuthenticationService
{
        Task<RegisterResponseDto?> Register(RegisterRequest request, CancellationToken cancellationToken);
        Task<AuthResponseDto?> Login(LoginRequest request, CancellationToken cancellationToken);
}
