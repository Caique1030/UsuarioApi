
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UsuarioApi.Models;

namespace UsuarioApi.Service
{
    public class TokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[] {
                new Claim("UserName", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };

            var chave = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(chave);
            }

            var signingKey = new SymmetricSecurityKey(chave);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
