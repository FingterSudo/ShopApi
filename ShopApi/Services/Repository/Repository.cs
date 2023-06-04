using Microsoft.IdentityModel.Tokens;
using ShopApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ShopApi.Services.Repository
{
    public class Repository : IRepository
    {
        private readonly IConfiguration _configuration;
        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(UserLogin user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                    );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public Task<string> GenerationsToke()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRefreshToken()
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshToken()
        {
            throw new NotImplementedException();
        }

        public void SetRefreshToken()
        {
            throw new NotImplementedException();
        }

        enum Status
        {

        }
    }
}
