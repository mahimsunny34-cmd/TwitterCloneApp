using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos;
using TwitterClone.Domain.Entities;
using TwitterClone.Application;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);   
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
           var createdUser = _userService.CreateUser(createUserDto);
            if (createdUser == null)
            {
                return BadRequest("Invalid user data or email already exists");
            }
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        { 
            var userExists=_userService.UpdateUser(id, updateUserDto);
            if(userExists == null)
            {
                return NotFound("User not found");
            }


            return Ok(userExists);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var removeUser = _userService.DeleteUser(id);
            if (!removeUser)
            {
                return NotFound("User not found");
            }
            return Ok("User deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id) 
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }
    }
}
