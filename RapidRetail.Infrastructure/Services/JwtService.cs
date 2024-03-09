using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RapidRetail.Domain.Entities;
using RapidRetail.Infrastructure.Models;

namespace RapidRetail.Infrastructure.Services
{
    public class JwtService
    {
        public static string GenerateToken(IConfiguration configuration, User user)
        {
            var jwtSetting = new JwtSetting(configuration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("userId",user.Id.ToString()),
                new Claim("username",user.Username),
                new Claim("role",user.Role)
            };

            var securityToken = new JwtSecurityToken(jwtSetting.Issuer,
                jwtSetting.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        public static void ConfigureJwtOptions(JwtBearerOptions options, IConfiguration configuration)
        {
            var jwtSetting = new JwtSetting(configuration);

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSetting.Issuer,
                ValidAudience = jwtSetting.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey))
            };
        }

        public static int? GetUserId(IHttpContextAccessor context)
        {
            try
            {
                return int.Parse(context.HttpContext?.User.FindFirstValue("userId"));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
