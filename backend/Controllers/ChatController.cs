using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Models.DTO;
using AutoMapper;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ChatController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserMessage>>> GetMessages()
        {
            var messages = await _context.UserMessages.ToListAsync();
            return messages;
        }

        [HttpPost]
        public async Task<ActionResult<List<UserMessage>>> SendMessage(UserMessageCreateDTO message)
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
    }
}