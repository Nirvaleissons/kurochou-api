using Kurochou.Domain.DTO.Auth;

namespace Kurochou.Domain.Interface.Service;

public interface IAuthenticationService
{
        Task<string> Register(RegisterRequest request, CancellationToken cancellationToken);
        Task<AuthResponseDTO> Login(LoginRequest request, CancellationToken cancellationToken);
}
