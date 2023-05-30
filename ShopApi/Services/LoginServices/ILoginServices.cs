using ShopApi.DTO;
using ShopApi.Models;

namespace ShopApi.Services.LoginServices
{
    public interface ILoginServices
    {
        Task<User> Register(IUserDTO userDTO);
        Task<string> Login(IUserDTO userDTO);
        Task<string> GetUserName();
    }
}
