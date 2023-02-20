﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LSCode.Notifiable.Unit.Test
{
    internal class NotifiableTest
    {
        [Test]
        public void Construtor_Success()
        {
            //Act
            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

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

            var notifiable = new Notifiable();

            var invalidNotifiable = new Notifiable();
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

            var notifiable = new Notifiable();

            var invalidNotifiable1 = new Notifiable();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new Notifiable();
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

            var notifiable = new Notifiable();

            var invalidNotifiable1 = new Notifiable();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new Notifiable();
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

            var notifiable = new Notifiable();

            var invalidNotifiable1 = new Notifiable();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new Notifiable();
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

            var notifiable = new Notifiable();

            var invalidNotifiable1 = new Notifiable();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new Notifiable();
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

            var notifiable = new Notifiable();

            var invalidNotifiable1 = new Notifiable();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new Notifiable();
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

            var notifiable = new Notifiable();

            var invalidNotifiable1 = new Notifiable();
            invalidNotifiable1.AddNotification(property1, message1);

            var invalidNotifiable2 = new Notifiable();
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