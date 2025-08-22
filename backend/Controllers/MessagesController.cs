using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Models.DTO;
using backend.Services.Interfaces;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IThreadService _threadService;

        public MessagesController(IMessageService messageService, IThreadService threadService)
        {
            _messageService = messageService;
            _threadService = threadService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Message>>> GetMessages([FromQuery] MessageReadDTO dto)
        {
            if (dto.UserId == null && dto.ThreadId == null)
            {
                return BadRequest("Invalid request data. Please include UserId and/or ThreadId.");
            }
            var data = await _messageService.GetMessages(dto);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var data = await _messageService.GetMessage(id);
            if(data == null) return NotFound($"Message with ID {id} not found.");
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> CreateMessage([FromBody] MessageCreateDTO dto)
        {
            if (dto.ThreadId == null)
            {
                var thread = await _threadService.CreateThread(dto.UserId, dto.Content.Substring(0, 20));
                dto.ThreadId = thread.Id;
            }

            var data = await _messageService.CreateMessage(dto);
            return Ok(data);
        }
    }
}
