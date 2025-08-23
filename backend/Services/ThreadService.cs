using backend.Data;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Models.DTO;

namespace backend.Services
{
    public class ThreadService : IThreadService
    {
        private readonly DataContext _context;
        private readonly IOpenAIService _openAIService;

        public ThreadService(DataContext context, IOpenAIService openAIService)
        {
            _context = context;
            _openAIService = openAIService;
        }

        public async Task<Models.Thread?> GetThread(int threadId)
        {
            var thread = await _context.Threads
                .AsNoTracking()
                .Include(t => t.Messages)
                .FirstOrDefaultAsync(t => t.Id == threadId);

            return thread;
        }

        public async Task<List<Models.Thread>> GetThreads(string userId)
        {
            var threads = await _context.Threads
                .AsNoTracking()
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return threads;
        }

        public async Task<Models.Thread> CreateThread(MessageCreateDTO dto)
        {
            var title = await _openAIService.GenerateThreadTitle(dto.Content);

            var thread = new Models.Thread
            {
                Title = title,
                UserId = dto.UserId
            };

            _context.Threads.Add(thread);
            await _context.SaveChangesAsync();
            return thread;
        }
    }
}
