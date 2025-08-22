using backend.Data;
using backend.Models;
using backend.Models.DTO;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class UserService : IUserService
    {   
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(UserCreateDTO dto)
        {
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            }; 

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<User?> GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
