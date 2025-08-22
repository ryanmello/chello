namespace backend.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public Thread Thread { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string? Content { get; set; }
        public bool IsHumanMessage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
