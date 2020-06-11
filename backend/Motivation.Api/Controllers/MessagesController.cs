using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Motivation.Services;

namespace Motivation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {       

        private readonly ILogger<MessagesController> _logger;
        private readonly IMessageService _messageService;

        public MessagesController(ILogger<MessagesController> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }        

        [HttpGet("/api/messages")]
        public IActionResult GetAllMessages()
        {
            var allMessages = _messageService.GetAllMessages();
            return Ok(allMessages);
        }

        [HttpGet("/api/messages/{id}")]
        public IActionResult GetMessageById(int id)
        {
            var message = _messageService.GetMessageById(id);
            return Ok(message);
        }

        [HttpGet("/api/messages/today")]
        public IActionResult GetTodaysMessage(string day)
        {
            var todaysMessage = _messageService.GetMessageByDayOfWeek(day);
            return Ok(todaysMessage);
        }
    }
}
