using Motivation.Data.Models;
using System.Collections.Generic;

namespace Motivation.Services.Readers
{
    public interface IMessageReader
    {
        IEnumerable<Message> GetAllMessagesFromDb();

        Message GetMessageFromDbById(int id);
    }
}