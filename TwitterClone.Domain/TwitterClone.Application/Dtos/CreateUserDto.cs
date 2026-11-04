using System.ComponentModel.DataAnnotations;

namespace TwitterClone.API.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public required string Password { get; set; }
    }
}
