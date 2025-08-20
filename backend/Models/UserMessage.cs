namespace backend.Models
{
    public class UserMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; } = 1;
        public string? Prompt { get; set; }
    }
}