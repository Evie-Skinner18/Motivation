using Microsoft.EntityFrameworkCore;
using Motivation.Data;
using Motivation.Data.Models;
using System.Collections.Generic;

namespace Motivation.Services.Readers
{
    public class MessageReader : IMessageReader
    {
        public DbContext _dbContext { get; set; }

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
            throw new System.NotImplementedException();
        }
    }
}
