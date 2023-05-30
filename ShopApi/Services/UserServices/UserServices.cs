using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using ShopApi.Data;
using ShopApi.DTO;
using ShopApi.Models;
using System.Security.Cryptography;

namespace ShopApi.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly ShopDatabaseContext _context;
        public UserServices (ShopDatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> Register(IUserDTO userDTO)
        {
            User user = new User();
            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.UserName = userDTO.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string> Login(IUserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(userDTO.UserName);
            if (user is null)
            {
                return nameof(Status.NotFound);
            }
            var result = VerifyPaswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt);
            if (!result)
            {
                return nameof(Status.BadRequest);
            }
            return nameof(Status.OK);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
       
        public bool VerifyPaswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        enum Status
        {
            OK,
            NotFound,
            BadRequest
        };

    }
}
