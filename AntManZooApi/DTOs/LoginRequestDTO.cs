using AntManZooClassLibrary.Validators;
using System.ComponentModel.DataAnnotations;

namespace AntManZooApi.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required]
        [PasswordValidator]
        public string? Password { get; set; }
    }
}
