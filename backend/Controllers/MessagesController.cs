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

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserMessage>>> GetMessages()
        {
            var data = await _messageService.GetUserMessages();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserMessage>>> SendMessage(UserMessageCreateDTO message)
        {

            var data = await _messageService.SendMessage(message);
            return Ok(data);
        }
    }
}
