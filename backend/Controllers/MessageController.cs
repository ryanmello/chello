using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Models.DTO;
using AutoMapper;
using backend.Services.Interfaces;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserMessage>>> GetMessages()
        {
            return await _messageService.GetUserMessages();
        }

        [HttpPost]
        public async Task<ActionResult<List<UserMessage>>> SendMessage(UserMessageCreateDTO message)
        {
            return await _messageService.SendMessage(message);
        }
    }
}
