using ShopApi.Models;

namespace ShopApi.Services.Repository;

public interface IRepository
{
    string CreateToken(UserLogin user);
    Task<string> GenerationsToke();
    Task<string> RefreshToken();
    void SetRefreshToken();
    Task<string> GetRefreshToken();
    enum Status
    {
        OK,
        NotFound,
        BadRequest
    };

}
