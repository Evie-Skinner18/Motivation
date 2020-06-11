using Microsoft.EntityFrameworkCore;
using Motivation.Data;
using Motivation.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Motivation.Services.Readers
{
    public class MessageReader : IMessageReader
    {
        public MotivationDbContext _dbContext { get; set; }

        public MessageReader(MotivationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Message> GetAllMessagesFromDb()
        {
            var allMessagesInDb = _dbContext.Messages;
            return allMessagesInDb;
        }

        public Message GetMessageFromDbById(int id)
        {
            var messageWithGivenId = _dbContext
                .Messages
                .Find(id);
            return messageWithGivenId;
        }

    }
}
