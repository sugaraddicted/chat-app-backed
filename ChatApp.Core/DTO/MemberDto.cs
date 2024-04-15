using System.ComponentModel.DataAnnotations;

namespace ChatApp.Core.DTO
{
    public class MemberDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Interests { get; set; }
        public string PhotoUrl { get; set; }
        public List<PhotoDto> Photos { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}
