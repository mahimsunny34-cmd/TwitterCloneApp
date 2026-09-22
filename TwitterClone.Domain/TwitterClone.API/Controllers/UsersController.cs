using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    FirstName="sunny",
                    Email="sun@gmail.com"
                },
                new User
                {
                    FirstName="sunny2",
                    Email="sun2@gmail.com"
                },
                new User
                {
                    FirstName="sunny3",
                    Email="sun3@gmail.com"
                }
            };
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            var newUser = new User
            {
                FirstName = "sunny4",
                Email = "s@dhcjks"
            };
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser()
        {
            return Ok("user updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser()
        {
            return Ok("user deleted");
        }
    }
}
