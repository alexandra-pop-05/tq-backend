using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TQ_Project.Application.Interfaces;
using TQ_Project.Application.Models.User;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserCreate>>> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCreate>> GetUserById(int id)
        {
           var result = await _userService.GetUserById(id);

            if(result is null)
            {
                return BadRequest("User not found!");
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<List<UserCreate>>> AddUser([FromBody] UserCreate user) //optional attribute expecting user object in the body
        {
          var result = await _userService.AddUser(user);

            if (result is null)
            {
                return BadRequest("User with the provided email already exists!");
            }
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserCreate>> UpdateUserById(int id, UserCreate requestedUser)
        {
            var result = await _userService.UpdateUserById(id, requestedUser);
            if (result is null) return NotFound("User not found!");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserCreate>>> DeleteUser(int id)
        {
            var result = await _userService.GetUserById(id);

            if (result is null) return NotFound("User not found!");

            await _userService.DeleteUser(id);
            return Ok("User deleted!");
        }


    }
}
