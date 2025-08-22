using backend.Data;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Services
{
    public class ThreadService : IThreadService
    {
        private readonly DataContext _context;
        public ThreadService(DataContext context)
        {
            _context = context;
        }

        public async Task<Models.Thread?> GetThread(int threadId)
        {
            var thread = await _context.Threads.AsNoTracking().FirstOrDefaultAsync(t => t.Id == threadId);
            return thread;
        }

        public async Task<Models.Thread> CreateThread(int userId, string title)
        {
            var thread = new Models.Thread
            {
                UserId = userId,
                Title = title
            };

            _context.Threads.Add(thread);
            await _context.SaveChangesAsync();
            return thread;
        }
    }
}
