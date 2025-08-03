using Kurochou.Domain.Common;
using Kurochou.Domain.Interface.Service;
using Kurochou.Domain.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Kurochou.DI;

public static class DependencyInjectionExtension
{
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration config)
        {
                services.AddServices();
                services.AddJwt(config);
                services.AddOpenApi();
                services.AddControllers();
                services.AddEndpointsApiExplorer();

                return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
                services.AddScoped<ITokenService, TokenService>();
                services.AddScoped<IAuthenticationService, AuthenticationService>();

                return services;
        }

        private static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration config)
        {
                services.Configure<JwtSettings>(config.GetSection("Jwt"));

                var jwtSettings = config.GetSection("Jwt").Get<JwtSettings>()!;

                services.AddAuthentication(options =>
                {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = jwtSettings.Issuer,
                                ValidAudience = jwtSettings.Audience,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                        };
                });

                services.AddAuthorizationBuilder()
                        .AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"))
                        .AddPolicy("UserPolicy", policy => policy.RequireRole("User", "Admin"));

                return services;
        }
}
