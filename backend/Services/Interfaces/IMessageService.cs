using backend.Models;
using backend.Models.DTO;

namespace backend.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessages(MessageReadDTO dto);
        Task<Message?> GetMessage(int id);
        Task<Message> CreateMessage(MessageCreateDTO dto);
    }
}
