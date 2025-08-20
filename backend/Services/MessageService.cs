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

        string resume = "Ryan Mello is a Software Engineer Intern at Tesla working on Robotaxi Software.";

        public async Task<ChelloMessage> SendMessage(UserMessageCreateDTO message)
        {
            var userMessage = _mapper.Map<UserMessage>(message);

            var response = await _openAIService.GetResponseAsync($"This is the resume: {resume}. Please respond to the users question: {message.Message}");

            var chelloMessage = new ChelloMessage
            {
                Message = response,
                UserId = message.UserId
            };

            _context.UserMessages.Add(userMessage);
            _context.ChelloMessages.Add(chelloMessage);

            await _context.SaveChangesAsync();

            var last = await _context.ChelloMessages
                .AsNoTracking()
                .OrderByDescending(m => m.Id)
                .FirstOrDefaultAsync();

            if (last == null)
            {
                return new ChelloMessage
                {
                    Message = "No messages found.",
                    UserId = message.UserId
                };
            }

            return last;
        }

        public async Task<List<UserMessage>> GetUserMessages()
        {
            var messages = await _context.UserMessages.ToListAsync();
            return messages;
        }

        public async Task<List<ChelloMessage>> GetChelloMessages()
        {
            var messages = await _context.ChelloMessages.ToListAsync();
            return messages;
        }
    }
}