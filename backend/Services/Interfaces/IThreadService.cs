using backend.Models.DTO;

namespace backend.Services.Interfaces
{
    public interface IThreadService
    {
        Task<Models.Thread?> GetThread(int threadId);
        Task<List<Models.Thread>> GetThreads(int userId);
        Task<Models.Thread> CreateThread(MessageCreateDTO dto);
    }
}
