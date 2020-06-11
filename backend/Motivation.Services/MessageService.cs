using Motivation.Data.Models;
using Motivation.Services.Readers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motivation.Services
{
    public class MessageService : IMessageService
    {
        private IMessageReader _messageReader;

        public MessageService(IMessageReader messageReader)
        {
            _messageReader = messageReader;
        }

        public IEnumerable<Message> GetAllMessages()
        {
            var allMessages = _messageReader.GetAllMessagesFromDb();
            if (allMessages == null)
            {
                throw new Exception("The reader has returned NULL");
            }
            else
            {
                return allMessages;
            }
        }       

        public Message GetMessageById(int id)
        {
            var messageWithGivenId = _messageReader.GetMessageFromDbById(id);
            return messageWithGivenId;
        }

        public Message GetMessageByDayOfWeek(string day)
        {
            var allMessages = _messageReader.GetAllMessagesFromDb().ToList();
            day = day.ToLower();

            switch (day)
            {
                case "monday": return allMessages[0];
                case "tuesday": return allMessages[1];
                case "wednesday": return allMessages[2];
                case "thursday": return allMessages[3];
                case "friday": return allMessages[4];
                case "saturday": return allMessages[5];
                case "sunday":return allMessages[6];
                default:
                   return null;
            };
        }
    }
}
