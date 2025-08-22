using AutoMapper;
using backend.Data;
using backend.Models;
using backend.Models.DTO;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class MessageService : IMessageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IOpenAIService _openAIService;

        public MessageService(DataContext context, IMapper mapper, IOpenAIService openAIService)
        {
            _context = context;
            _mapper = mapper;
            _openAIService = openAIService;
        }

        public async Task<Message> CreateMessage(MessageCreateDTO dto)
        {
            var userMessage = _mapper.Map<Message>(dto);
            userMessage.IsHumanMessage = true;

            var response = await _openAIService.GetResponseAsync($"This is the resume: {Constants.Resume}. Please respond to the users question: {dto.Content}");

            var chelloMessage = new Message
            {
                ThreadId = userMessage.ThreadId,
                Content = response,
                IsHumanMessage = false,
            };

            _context.Messages.Add(userMessage);
            _context.Messages.Add(chelloMessage);

            await _context.SaveChangesAsync();

            var last = await _context.Messages
                .AsNoTracking()
                .OrderByDescending(m => m.Id)
                .FirstOrDefaultAsync();

            if (last == null)
            {
                return new Message
                {
                    ThreadId = userMessage.ThreadId,
                    Content = "No messages found.",
                    IsHumanMessage = false,
                };
            }

            return last;
        }

        public Task<Message?> GetMessage(int id)
        {
            var message = _context.Messages.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            return message;
        }

        public async Task<List<Message>> GetMessages(MessageReadDTO dto)
        {
            var messages = await _context.Messages.ToListAsync();
            return messages;
        }
    }
}