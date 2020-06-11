using Motivation.Data.Models;
using System.Collections.Generic;

namespace Motivation.Services
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAllMessages();

        Message GetMessageById(int id);

        Message GetMessageByDayOfWeek(string day);
    }
}