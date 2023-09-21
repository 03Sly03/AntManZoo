using AntManZooClassLibrary.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntManZooClassLibrary.Models
{
    public class Staff
    {
        [Required]

        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z].*", ErrorMessage = "FirstName must start with an Uppercase Letter !")]
        public string? Firstname { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z\-]*", ErrorMessage = "LastName must be only Uppercase !")]
        public string? Lastname { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required]
        [PasswordValidator]
        public string? Password { get; set; }

    }
}
