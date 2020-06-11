using Motivation.Data.Models;
using System.Collections.Generic;

namespace Motivation.Services
{
    public interface IMessageService
    {
        public IEnumerable<Message> GetAllMessages();

        public Message GetMessageById(int id);
    }
}