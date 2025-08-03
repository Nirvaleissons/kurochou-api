using Kurochou.Domain.DTO.Auth;
using Kurochou.Domain.Interface.Service;

namespace Kurochou.Domain.Service;

public class AuthenticationService(ITokenService tokenService) : IAuthenticationService
{
        public Task<AuthResponseDTO> Login(LoginRequest request, CancellationToken cancellationToken)
        {
                throw new NotImplementedException();
        }

        public Task<string> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
                throw new NotImplementedException();
        }
}
