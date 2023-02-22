using LSCode.Notifications.Models;
using NUnit.Framework;

namespace LSCode.Notifications.Unit.Test.Models
{
    internal class NotificationTest
    {
        [Test]
        [TestCase("Property1", "Message1")]
        [TestCase("Property2", "Message2")]
        [TestCase("Property3", "Message3")]
        public void Construtor_Success(string property, string message)
        {
            //Act
            var notification = new Notification(property, message);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notification.Property, Is.EqualTo(property));
                Assert.That(notification.Message, Is.EqualTo(message));
            });
        }
    }
}