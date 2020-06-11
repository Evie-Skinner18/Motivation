using NUnit.Framework;
using Moq;
using Motivation.Services.Readers;
using Motivation.Data.Models;
using System.Collections.Generic;
using Motivation.Services;

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


        /*
         *  public IEnumerable<Message> GetAllMessages()
        {
            throw new NotImplementedException();
        }

        public Message GetMessageById(int id)
        {
            throw new NotImplementedException();
        }
         * 
         * 
         * 
         * 
         */
    }
}