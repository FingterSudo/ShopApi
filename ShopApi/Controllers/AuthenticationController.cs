using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Data;
using ShopApi.DTO;
using ShopApi.Models;
using ShopApi.Services.UserServices;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ShopDatabaseContext _context;
        private readonly IUserServices _userServices;
        public AuthenticationController(ShopDatabaseContext context, IUserServices userServices)
        {
            _context = context;
            _userServices = userServices;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(IUserDTO userDTO)
        {
            return await _userServices.Register(userDTO);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(IUserDTO userDTO)
        {
            var result = await _userServices.Login(userDTO);
            if (result == "NotFound")
            {
                return NotFound("Invalid refesh token");
            }
            else if(result == "BabRequest")
            {
                return BadRequest("Token expired");
            }
            return result;
        }
    }
}
