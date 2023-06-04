using Microsoft.EntityFrameworkCore;
using ShopApi.Data;

namespace ShopApi.Services.UserRoles
{
    public class UserRoles: IUserRoles
    {
        private readonly ShopDatabaseContext _context;
        public UserRoles(ShopDatabaseContext context)
        {
            _context = context;
        }
        public string GetRolesByUserId(int userId)
        {
            var roles = _context.UserRoles.Include(s => s.Roles).FirstOrDefaultAsync(x => x.UserId == userId);
            if (roles is null)
            {
                return null;
            }
            return roles.ToString();
        }
    }
}
