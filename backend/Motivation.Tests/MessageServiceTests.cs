using NUnit.Framework;
using Moq;
using Motivation.Services.Readers;
using Motivation.Data.Models;
using System.Collections.Generic;
using Motivation.Services;
using System;

namespace Motivation.Tests
{
    public class MessageServiceTests
    {
        private Mock<IMessageReader> _messageReader;
        private List<Message> _messages;

        [SetUp]
        public void Setup()
        {
            _messages = new List<Message>()
            {
                new Message
                {
                    Id = 1,
                    Text = "Hello!",
                    Author = "Evie",
                    ImageUrl = "https://4.bp.blogspot.com/-uGSkO0MqBLs/VzwX1AIqIKI/AAAAAAAAAkc/pTovQkMPi4kNCECWHXreP7Tk6qB07Py3gCLcB/s1600/GB-E424-SM.png"
                },
                new Message
                {
                    Id = 2,
                    Text = "Have a lush day!",
                    Author = "Mr Bean",
                    ImageUrl = "https://4.bp.blogspot.com/-uGSkO0MqBLs/VzwX1AIqIKI/AAAAAAAAAkc/pTovQkMPi4kNCECWHXreP7Tk6qB07Py3gCLcB/s1600/GB-E424-SM.png"
                },
                new Message
                {
                    Id = 3,
                    Text = "Have fun",
                    Author = "Mr S. Baldrick",
                    ImageUrl = "https://4.bp.blogspot.com/-uGSkO0MqBLs/VzwX1AIqIKI/AAAAAAAAAkc/pTovQkMPi4kNCECWHXreP7Tk6qB07Py3gCLcB/s1600/GB-E424-SM.png"
                }
            };

            _messageReader = new Mock<IMessageReader>();
        }

        [Test]
        public void CanGetAllMessages_ShouldReturnAnIEnumerableOfAllMessages()
        {
            _messageReader.Setup(r => r.GetAllMessagesFromDb()).Returns(_messages);

            var messageService = new MessageService(_messageReader.Object);
            var allMessages = messageService.GetAllMessages();

            Assert.That(allMessages, Is.EqualTo(_messages));
        }

        [Test]
        public void CanGetAllMessages_ShouldReturnAnExceptionWhenTheValueReturnedFromTheReaderIsNull()
        {
            List<Message> invalidResult = null;
            _messageReader.Setup(r => r.GetAllMessagesFromDb()).Returns(invalidResult);

            var messageService = new MessageService(_messageReader.Object);

            var exception = Assert.Throws<Exception>(() => messageService.GetAllMessages());
            Assert.That(exception.Message, Is.EqualTo("The reader has returned NULL"));
        }

        [Test]
        public void CanGetMessageById_ShouldReturnTheMessageCorrespondingToTheGivenId()
        {
            _messageReader.Setup(r => r.GetMessageFromDbById(1)).Returns(_messages[0]);

            var messageService = new MessageService(_messageReader.Object);
            var helloMessage = messageService.GetMessageById(1);
            var expectedMessage = _messages[0];

            Assert.That(helloMessage, Is.EqualTo(expectedMessage));
        } 
        
        [Test]
        public void CanGetMessageForCorrectDay_ShouldReturnSundaysMessage()
        {

        }
    }
}