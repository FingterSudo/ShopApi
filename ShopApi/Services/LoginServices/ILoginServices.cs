using ShopApi.DTO;
using ShopApi.Models;

namespace ShopApi.Services.LoginServices
{
    public interface ILoginServices
    {
        Task<UserLogin> Register(UserDTO userDTO);
        Task<string> Login(UserDTO userDTO);
        Task<string> GetUserName();
    }
}
