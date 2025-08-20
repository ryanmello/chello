namespace backend.Models.DTO
{
    public class ChelloMessageCreateDTO
    {
        public int UserId { get; set; } = 1;
        public string? Prompt { get; set; }
    }
}
