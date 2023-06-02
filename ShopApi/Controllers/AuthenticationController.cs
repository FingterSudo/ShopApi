using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Data;
using ShopApi.DTO;
using ShopApi.Models;
using ShopApi.Services.Repository;
using ShopApi.Services.UserServices;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ShopDatabaseContext _context;
        private readonly IUserServices _userServices;
        private readonly IRepository _repository; 
        public AuthenticationController(ShopDatabaseContext context, IUserServices userServices, IRepository repository)
        {
            _context = context;
            _userServices = userServices;
            _repository = repository;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserLogin>> Register(UserDTO _userDTO) => await _userServices.Register(_userDTO);
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDTO userDTO)
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
            var user = await _userServices.GetUserByUserDTO(userDTO);
            if ( user is null)
            {
                return NotFound("Invalid refesh token");
            }
            var token = CreateToken(user);
            return token;
        }
        private string CreateToken(UserLogin user)
        {
            return _repository.CreateToken(user);
        }
    }
}
