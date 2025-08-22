using backend.Models.DTO;

namespace backend.Services.Interfaces
{
    public interface IUserService
    {
        Task<Models.User?> GetUser(int userId);
        Task<Models.User> CreateUser(UserCreateDTO dto);
    }
}
