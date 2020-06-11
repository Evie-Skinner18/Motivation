using NUnit.Framework;

namespace Motivation.Tests
{
    public class Tests
    {
        

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanGetAllMessages_ShouldReturnAnIEnumerableOfAllMessages()
        {
            Assert.Pass();
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