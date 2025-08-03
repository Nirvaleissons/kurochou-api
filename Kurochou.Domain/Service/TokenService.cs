using Kurochou.Domain.Common;
using Kurochou.Domain.DTO.Auth;
using Kurochou.Domain.Interface.Service;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kurochou.Domain.Service;

public class TokenService(IOptions<JwtSettings> settings) : ITokenService
{
        private readonly JwtSettings _settings = settings.Value;

        public string GenerateToken(string username, string role)
        {
                var claims = new[]
                {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, role)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: _settings.Issuer,
                        audience: _settings.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
                        signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
        }
}
