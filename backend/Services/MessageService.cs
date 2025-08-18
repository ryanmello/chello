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

        public MessageService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserMessage>> SendMessage(UserMessageCreateDTO message)
        {
            var userMessage = _mapper.Map<UserMessage>(message);
            _context.UserMessages.Add(userMessage);
            await _context.SaveChangesAsync();

            // send resume and message to AI
            // create an AI message
            // save that AI message to the database
            // return the AI message

            var messages = await _context.UserMessages.ToListAsync();
            return messages;
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