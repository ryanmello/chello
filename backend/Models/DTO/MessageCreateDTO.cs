namespace backend.Models.DTO
{
    public class MessageCreateDTO
    {
        public int? ThreadId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
    }
}
