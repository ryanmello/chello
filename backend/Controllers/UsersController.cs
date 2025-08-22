using backend.Models;
using backend.Models.DTO;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserCreateDTO dto)
        {
            var user = await _userService.CreateUser(dto);
            return user;
        }
    }
}
