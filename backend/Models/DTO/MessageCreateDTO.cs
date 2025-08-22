namespace backend.Models.DTO
{
    public class MessageCreateDTO
    {
        public int UserId { get; set; }
        public int? ThreadId { get; set; }
        public string Content { get; set; } = null!;
    }
}
