using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly DataContext _context;

        public ChatController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserMessage>>> GetMessages()
        {
            var messages = await _context.UserMessages.ToListAsync();
            return messages;
        }

        [HttpPost]
        public async Task<ActionResult<List<UserMessage>>> SendMessage(UserMessage message)
        {
            _context.UserMessages.Add(message);
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