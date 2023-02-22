using LSCode.Notifications.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LSCode.Notifications.Unit.Test.Models
{
    //Class that inherits from notifiable, as its constructor is protected, so it is necessary for another class to inherit from notifiable to create an instance and use its methods.
    internal class NotifiableClassFake : Notifiable { }

    //Tests
    internal class NotifiableTest
    {
        [Test]
        public void Construtor_Success()
        {
            //Act
            var notifiable = new NotifiableClassFake();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.True);
                Assert.That(notifiable.Invalid, Is.False);
                Assert.That(notifiable.Notifications, Is.Empty);
            });
        }

        [Test]
        public void AddNotification_Add_With_Property_And_Message_Parameters_Success()
        {
            //Arrange
            var property = "NotificationProperty";
            var message = "NotificationMessage";

            var notifiable = new NotifiableClassFake();

            //Act
            notifiable.AddNotification(property, message);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(1));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message));
            });
        }

        [Test]
        public void AddNotification_Add_With_Notification_Parameters_Success()
        {
            //Arrange
            var property = "NotificationProperty";
            var message = "NotificationMessage";

            var notifiable = new NotifiableClassFake();

            var notification = new Notification(property, message);

            //Act
            notifiable.AddNotification(notification);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(1));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message));
            });
        }

        [Test]
        public void AddNotification_Add_With_IEnumerable_Of_Notification_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            IEnumerable<Notification> invalidNotificationList = new List<Notification>
            {
                new Notification(property1, message1),
                new Notification(property2, message2),
                new Notification(property3, message3)
            };

            //Act
            notifiable.AddNotification(invalidNotificationList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_List_Of_Notification_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            List<Notification> invalidNotificationList = new List<Notification>
            {
                new Notification(property1, message1),
                new Notification(property2, message2),
                new Notification(property3, message3)
            };

            //Act
            notifiable.AddNotification(invalidNotificationList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_IList_Of_Notification_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            IList<Notification> invalidNotificationList = new List<Notification>
            {
                new Notification(property1, message1),
                new Notification(property2, message2),
                new Notification(property3, message3)
            };

            //Act
            notifiable.AddNotification(invalidNotificationList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_ICollection_Of_Notification_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            ICollection<Notification> invalidNotificationList = new List<Notification>
            {
                new Notification(property1, message1),
                new Notification(property2, message2),
                new Notification(property3, message3)
            };

            //Act
            notifiable.AddNotification(invalidNotificationList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_IReadOnlyList_Of_Notification_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            IReadOnlyList<Notification> invalidNotificationList = new List<Notification>
            {
                new Notification(property1, message1),
                new Notification(property2, message2),
                new Notification(property3, message3)
            };

            //Act
            notifiable.AddNotification(invalidNotificationList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_IReadOnlyCollection_Of_Notification_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            IReadOnlyCollection<Notification> invalidNotificationList = new List<Notification>
            {
                new Notification(property1, message1),
                new Notification(property2, message2),
                new Notification(property3, message3)
            };

            //Act
            notifiable.AddNotification(invalidNotificationList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_Notifiable_Parameter_Success()
        {
            //Arrange
            var property = "NotificationProperty";
            var message = "NotificationMessage";

            var notifiable = new NotifiableClassFake();

            var invalidNotifiable = new NotifiableClassFake();
            invalidNotifiable.AddNotification(property, message);

            //Act
            notifiable.AddNotification(invalidNotifiable);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(1));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message));
            });
        }

        [Test]
        public void AddNotification_Add_With_IEnumerable_Of_Notifiable_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            var invalidNotifiable1 = new NotifiableClassFake();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new NotifiableClassFake();
            invalidNotifiable2.AddNotification(property2, message2);
            invalidNotifiable2.AddNotification(property3, message3);

            IEnumerable<Notifiable> invalidNotifiableList = new List<Notifiable>
            {
                invalidNotifiable1,
                invalidNotifiable2
            };

            //Act
            notifiable.AddNotification(invalidNotifiableList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_List_Of_Notifiable_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            var invalidNotifiable1 = new NotifiableClassFake();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new NotifiableClassFake();
            invalidNotifiable2.AddNotification(property2, message2);
            invalidNotifiable2.AddNotification(property3, message3);

            List<Notifiable> invalidNotifiableList = new List<Notifiable>
            {
                invalidNotifiable1,
                invalidNotifiable2
            };

            //Act
            notifiable.AddNotification(invalidNotifiableList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_IList_Of_Notifiable_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            var invalidNotifiable1 = new NotifiableClassFake();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new NotifiableClassFake();
            invalidNotifiable2.AddNotification(property2, message2);
            invalidNotifiable2.AddNotification(property3, message3);

            IList<Notifiable> invalidNotifiableList = new List<Notifiable>()
            {
                invalidNotifiable1,
                invalidNotifiable2
            };

            //Act
            notifiable.AddNotification(invalidNotifiableList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_ICollection_Of_Notifiable_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            var invalidNotifiable1 = new NotifiableClassFake();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new NotifiableClassFake();
            invalidNotifiable2.AddNotification(property2, message2);
            invalidNotifiable2.AddNotification(property3, message3);

            ICollection<Notifiable> invalidNotifiableList = new List<Notifiable>()
            {
                invalidNotifiable1,
                invalidNotifiable2
            };

            //Act
            notifiable.AddNotification(invalidNotifiableList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_IReadOnlyList_Of_Notifiable_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            var invalidNotifiable1 = new NotifiableClassFake();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new NotifiableClassFake();
            invalidNotifiable2.AddNotification(property2, message2);
            invalidNotifiable2.AddNotification(property3, message3);

            IReadOnlyList<Notifiable> invalidNotifiableList = new List<Notifiable>()
            {
                invalidNotifiable1,
                invalidNotifiable2
            };

            //Act
            notifiable.AddNotification(invalidNotifiableList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }

        [Test]
        public void AddNotification_Add_With_IReadOnlyCollection_Of_Notifiable_Parameter_Success()
        {
            //Arrange
            var property1 = "NotificationProperty1";
            var message1 = "NotificationMessage1";

            var property2 = "NotificationProperty2";
            var message2 = "NotificationMessage2";

            var property3 = "NotificationProperty3";
            var message3 = "NotificationMessage3";

            var notifiable = new NotifiableClassFake();

            var invalidNotifiable1 = new NotifiableClassFake();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new NotifiableClassFake();
            invalidNotifiable2.AddNotification(property2, message2);
            invalidNotifiable2.AddNotification(property3, message3);

            IReadOnlyCollection<Notifiable> invalidNotifiableList = new List<Notifiable>()
            {
                invalidNotifiable1,
                invalidNotifiable2
            };

            //Act
            notifiable.AddNotification(invalidNotifiableList);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(notifiable.Valid, Is.False);
                Assert.That(notifiable.Invalid, Is.True);
                Assert.That(notifiable.Notifications, Is.Not.Empty);
                Assert.That(notifiable.Notifications, Has.Count.EqualTo(3));
                Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property1));
                Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message1));
                Assert.That(notifiable.Notifications.ToList()[1].Property, Is.EqualTo(property2));
                Assert.That(notifiable.Notifications.ToList()[1].Message, Is.EqualTo(message2));
                Assert.That(notifiable.Notifications.ToList()[2].Property, Is.EqualTo(property3));
                Assert.That(notifiable.Notifications.ToList()[2].Message, Is.EqualTo(message3));
            });
        }
    }
}