using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Motivation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {       

        private readonly ILogger<MessagesController> _logger;

        public MessagesController(ILogger<MessagesController> logger)
        {
            _logger = logger;
        }        

        [HttpGet("/api/messages")]
        public IActionResult GetAllMessages()
        {
            //var allBooks = _bookService.GetAllBooks();
            return Ok("HELLO");
        }

        [HttpGet("/api/messages/{id}")]
        public IActionResult GetMessageById(int id)
        {
            //var allBooks = _bookService.GetAllBooks();
            return Ok($"I am message {id}");
        }


    }
}
