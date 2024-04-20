using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Api.Input
{
    public class RegisterInput
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly? DateOfBirth { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
