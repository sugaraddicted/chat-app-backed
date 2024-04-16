using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Core.Interfaces;

namespace ChatApp.Core.Entities
{
    [Table("Photos")]
    public class Photo : IEntityBase
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
