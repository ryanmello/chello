using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
        public string Title { get; set; } = null!;
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
