namespace backend.Models.DTO
{
    public class UserMessageCreateDTO
    {
        public int UserId { get; set; } = 1;
        public string? Message { get; set; }
    }
}
