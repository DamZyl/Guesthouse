using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Guesthouse.Infrastructure.DTO;
using Guesthouse.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Guesthouse.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly IConfiguration _configuration;

        public JwtHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtDto CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString())
            };

            var parseExpiryMinutes = double.TryParse(_configuration["Jwt:ExpiryMinutes"],
                out double expiryMinutes);

            var expires = now.AddMinutes(expiryMinutes);
            
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256);
            
            var jwt = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                Expires = expires.ToTimeStamp()
            };
        }
    }
}