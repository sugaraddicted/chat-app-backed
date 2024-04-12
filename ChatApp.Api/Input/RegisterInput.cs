using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Api.Input
{
    public class RegisterInput
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
