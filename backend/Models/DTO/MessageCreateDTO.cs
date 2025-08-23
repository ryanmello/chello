namespace backend.Models.DTO
{
    public class MessageCreateDTO
    {
        public string UserId { get; set; } = null!;
        public int? ThreadId { get; set; }
        public string Content { get; set; } = null!;
    }
}
