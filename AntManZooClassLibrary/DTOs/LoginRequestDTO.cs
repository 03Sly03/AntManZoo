using System.ComponentModel.DataAnnotations;

namespace AntManZooClassLibrary.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required]
        //[PasswordValidator]
        public string? Password { get; set; }
    }
}
