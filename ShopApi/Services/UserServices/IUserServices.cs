using ShopApi.DTO;
using ShopApi.Models;

namespace ShopApi.Services.UserServices
{
    public interface IUserServices
    {
        Task<UserLogin> Register(UserDTO userDTO);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        Task<string> Login(UserDTO userDTO);
        Task<UserLogin> GetUserByUserDTO(UserDTO userDTO);
        bool VerifyPaswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        enum Status
        {
            OK,
            NotFound,
            BadRequest
        };

    }
}
