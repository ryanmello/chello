using AutoMapper;
using backend.Data;
using backend.Models;
using backend.Models.DTO;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class UserService : IUserService
    {   
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(UserCreateDTO dto)
        {
            var user = _mapper.Map<User>(dto);

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
