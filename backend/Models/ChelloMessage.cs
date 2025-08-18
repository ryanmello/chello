namespace backend.Models
{
    public class ChelloMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; } = 1;
        public string? Text { get; set; }
    }
}
