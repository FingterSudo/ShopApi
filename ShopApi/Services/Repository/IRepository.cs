using ShopApi.Models;

namespace ShopApi.Services.Repository;

public interface IRepository
{
    Task<string> CreateToken(User user);
    Task<string> RefreshToken();
    void SetRefreshToken();
    enum Status{
        OK,
        NotFound,
        BadRequest
    };

}
