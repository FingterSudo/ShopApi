using ShopApi.Models;

namespace ShopApi.Services.Repository
{
    public class Repository : IRepository
    {
        public Task<string> CreateToken(User user)
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
