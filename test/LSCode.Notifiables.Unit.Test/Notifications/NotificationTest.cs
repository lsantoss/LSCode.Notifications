using LSCode.Notifiables.Notifications;
using NUnit.Framework;

namespace LSCode.Notifiables.Unit.Test.Notifications
{
    internal class NotificationTest
    {
        [Test]
        public void Construtor_Success()
        {
            //Arrange
            var property = "Property";
            var message = "Message";

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