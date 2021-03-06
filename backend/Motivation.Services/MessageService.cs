﻿using Motivation.Data.Models;
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

        public Message GetMessageByDayOfWeek(int day)
        {
            var allMessages = _messageReader.GetAllMessagesFromDb().ToList();
            day = day - 1;

            var todaysMessage = allMessages[day];
            return todaysMessage;
        }
    }
}
