using System.ComponentModel.DataAnnotations;
using ChatApp.Core.Extensions;
using ChatApp.Core.Interfaces;

namespace ChatApp.Core.Entities
{
    public class User: IEntityBase
    {
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Interests { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Photo> Photos { get; set; } = new();
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
    }
}
