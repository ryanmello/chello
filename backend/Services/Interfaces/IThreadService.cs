namespace backend.Services.Interfaces
{
    public interface IThreadService
    {
        Task<Models.Thread?> GetThread(int threadId);
        Task<Models.Thread> CreateThread(int userId, string title);
    }
}
