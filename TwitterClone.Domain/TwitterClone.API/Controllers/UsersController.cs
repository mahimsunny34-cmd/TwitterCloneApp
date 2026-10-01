using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserRepository _userRepo;
        public UsersController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepo.ShowUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if(string.IsNullOrWhiteSpace(createUserDto.FirstName) || 
                string.IsNullOrWhiteSpace(createUserDto.Email) || 
                string.IsNullOrWhiteSpace(createUserDto.LastName))
            {
                return BadRequest("User data is null");
            }

            var emailExists = _userRepo.GetUserByEmail(createUserDto.Email);
            if (emailExists != null)
            {
                return BadRequest("User with this email already exists");
            }

            var user = new User //User object is created by the CreateUserDto object datas and stored in the user variable.
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email
            };

            var createdUser=_userRepo.AddUser(user); //The user object is added to the UserRepository and stored in the createdUser variable.
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            if(Guid.Empty == id || string.IsNullOrWhiteSpace(updateUserDto.FirstName) || string.IsNullOrWhiteSpace(updateUserDto.LastName))
            {
                return BadRequest("User ID and user data are required");
            }

            var userExists=_userRepo.UpdateUser(id, updateUserDto.FirstName, updateUserDto.LastName);
            if(userExists == null)
            {
                return NotFound("User not found");
            }
            return Ok(userExists);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var removeUser = _userRepo.DeleteUser(id);
            if (removeUser == null)
            {
                return NotFound("User not found");

            }
            else
            {
                return Ok(removeUser);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id) 
        {
            if(Guid.Empty == id)
            {
                return BadRequest("User ID is required");
            }
            var user = _userRepo.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }
    }
}
