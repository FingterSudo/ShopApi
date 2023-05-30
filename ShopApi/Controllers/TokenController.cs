using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Data;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ShopDatabaseContext _context;
        public TokenController(IConfiguration configuration, ShopDatabaseContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        //public async Task<IActionResult> Post(UserInfor _userData)
        //{
        //    if(_userData !=null && _userData.Ema)
        //}

    }
}
