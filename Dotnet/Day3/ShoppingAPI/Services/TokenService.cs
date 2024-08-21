using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _tokenKey;
        private readonly SymmetricSecurityKey _symKey;

        public TokenService(IConfiguration configuration) 
        {
            _tokenKey = configuration.GetSection("TokenKey").Value.ToString();
            _symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenKey));
        }
        public string GenerateToken(string username)
        {
            string token ="";
            var claims = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                });
            var tokenDesc = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(_symKey, SecurityAlgorithms.HmacSha256Signature)
             };

            
            var handler = new JwtSecurityTokenHandler();
            var gtoken = handler.CreateToken(tokenDesc);
            token = handler.WriteToken(gtoken);
            return token;
        }
    }
}
