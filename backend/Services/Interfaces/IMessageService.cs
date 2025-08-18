using backend.Models;
using backend.Models.DTO;

namespace backend.Services.Interfaces
{
    public interface IMessageService
    {
        Task<List<UserMessage>> SendMessage(UserMessageCreateDTO message);
        Task<List<UserMessage>> GetUserMessages();
        Task<List<ChelloMessage>> GetChelloMessages();
    }
}
