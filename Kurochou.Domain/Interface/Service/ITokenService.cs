using Kurochou.Domain.DTO.Auth;

namespace Kurochou.Domain.Interface.Service;

public interface ITokenService
{
        string GenerateToken(string username, string role);
}
