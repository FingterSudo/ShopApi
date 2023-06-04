using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopApi.Data;
using ShopApi.Models;
using ShopApi.Services.UserRoles;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ShopApi.Services.Repository
{
    public class Repository : IRepository, IUserRoles
    {
        private readonly IConfiguration _configuration;
        private readonly ShopDatabaseContext _context;
        private readonly ILogger _logger;
        public Repository(IConfiguration configuration, ShopDatabaseContext context, ILogger logger)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }
        public  string CreateToken(UserLogin user)
        {
            string roles =  GetRolesByUserId(user.Id);
            List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, roles)
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
        public string GetRolesByUserId(int userId)
        {
            var roles =  _context.UserRoles.Include(s => s.Roles).First(x => x.UserId == userId);
            if (roles is null)
            {
                return null;
            }
            return roles.ToString();
        }
        enum Status
        {

        }
    }
}
