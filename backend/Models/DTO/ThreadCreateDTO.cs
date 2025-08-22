namespace backend.Models.DTO
{
    public class ThreadCreateDTO
    {
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
    }
}
