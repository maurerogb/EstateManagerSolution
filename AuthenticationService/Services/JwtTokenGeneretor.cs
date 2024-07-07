using Authentication.Contract;
using Authentication.Models;
using EstateManager.Dto;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Services
{
    public class JwtTokenGeneretor(IOptions< JwtOptions> jwtOptions) : IJwtTokenGenerator
    {
        public string GenerateToken(UserDTO user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes( jwtOptions.Value.secret );
            var cliams = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub , user.Identifier.ToString()),
                new Claim(JwtRegisteredClaimNames.Email , user.UserEmail),
                new Claim(JwtRegisteredClaimNames.Name , user.UserName)
            };

            var tokenDescrition = new SecurityTokenDescriptor{
                 Issuer = jwtOptions.Value.Issuer,
                 Audience = jwtOptions.Value.Audience,
                 Subject = new ClaimsIdentity(cliams),
                 Expires = DateTime.UtcNow.AddDays(1),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(tokenDescrition);
            return handler.WriteToken(token);

        }
    }
}
