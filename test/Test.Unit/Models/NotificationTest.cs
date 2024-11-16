using LSCode.Notifications.Models;

namespace LSCode.Notifications.Test.Unit.Models;

[TestFixture]
internal class NotificationTest
{
    [Test]
    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase("property", "message")]
    public void Construtor_MustAssignTheValuesCorrectly(string property, string message)
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