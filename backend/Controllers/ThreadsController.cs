using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThreadsController : ControllerBase
    {
        private readonly IThreadService _threadService;

        public ThreadsController(IThreadService threadService)
        {
            _threadService = threadService;
        }

        [HttpGet("{threadId}")]
        public async Task<ActionResult<Models.Thread>> GetThread(int threadId)
        {
            var thread = await _threadService.GetThread(threadId);

            if (thread == null)
            {
                return NotFound($"Thread with ID {threadId} not found.");
            }

            return thread;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Thread>>> GetThreads([FromQuery] int userId)
        {
            return await _threadService.GetThreads(userId);
        }
    }
}
