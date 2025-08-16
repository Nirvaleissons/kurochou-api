using Kurochou.Domain.DTO.Auth;
using Kurochou.Domain.DTO.Auth.Response;
using Kurochou.Domain.Enum;
using Kurochou.Domain.Interface.Repository;
using Kurochou.Domain.Interface.Service;
using Kurochou.Domain.Model;

namespace Kurochou.Domain.Service;

public class AuthenticationService(
        ITokenService tokenService,
        IUserRepository repository) : IAuthenticationService
{
        public async Task<RegisterResponseDto?> Register(RegisterRequest request, CancellationToken cancellationToken)
        {
                var existingUsers = await repository.GetAllAsync(cancellationToken);

                if (existingUsers.Any(u => u.Username == request.Username))
                        return new RegisterResponseDto(false, "Username already exists");
                
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                var user = new User
                {
                        Username = request.Username,
                        PasswordHash = passwordHash,
                        Role = (UserRole)request.Role
                };
                
                await repository.InsertAsync(user);

                return new RegisterResponseDto(true, "User registered successfully");
        }
        
        public async Task<AuthResponseDto?> Login(LoginRequest request, CancellationToken cancellationToken)
        {
                var users = await repository.GetAllAsync(cancellationToken);
                var user = users.FirstOrDefault(u => u.Username == request.Username);

                if (user is null)
                        return null;
                
                var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
                if (!isPasswordValid)
                        return null;

                var token = tokenService.GenerateToken(user.Username, user.Role.ToString());

                return new AuthResponseDto(token, 60, user.Role.ToString());
        }
}
