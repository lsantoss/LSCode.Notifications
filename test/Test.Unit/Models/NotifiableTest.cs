using LSCode.Notifications.Models;

namespace LSCode.Notifications.Test.Unit.Models;

[TestFixture]
internal class NotifiableTest
{
    [Test]
    public void Construtor_MustAssignTheValuesCorrectly()
    {
        //Act
        var notifiable = new NotifiableInherited();

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.True);
            Assert.That(notifiable.Invalid, Is.False);
            Assert.That(notifiable.Notifications, Is.Empty);
        });
    }

    [Test]
    [TestCase(null, null)]
    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase("property", "message")]
    public void AddNotification_AddWithPropertyAndMessage_ValidParameters_ShouldAdd(string property, string message)
    {
        //Arrange
        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(property, message);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.False);
            Assert.That(notifiable.Invalid, Is.True);
            Assert.That(notifiable.Notifications, Has.Count.EqualTo(1));
            Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(property));
            Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(message));
        });
    }

    [Test]
    [TestCaseSource(typeof(NotifiableTestCaseSource), nameof(NotifiableTestCaseSource.AddNotification_AddWithNotification_ValidParameter_ShouldAdd))]
    public void AddNotification_AddWithNotification_ValidParameter_ShouldAdd(Notification notification)
    {
        //Arrange
        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(notification);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.False);
            Assert.That(notifiable.Invalid, Is.True);
            Assert.That(notifiable.Notifications, Has.Count.EqualTo(1));
            Assert.That(notifiable.Notifications.ToList()[0].Property, Is.EqualTo(notification.Property));
            Assert.That(notifiable.Notifications.ToList()[0].Message, Is.EqualTo(notification.Message));
        });
    }

    [Test]
    [TestCase(null)]
    public void AddNotification_AddWithNotification_NullParameter_ShouldNotAdd(Notification notification)
    {
        //Arrange
        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(notification);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.True);
            Assert.That(notifiable.Invalid, Is.False);
            Assert.That(notifiable.Notifications, Is.Empty);
        });
    }

    [Test]
    [TestCaseSource(typeof(NotifiableTestCaseSource), nameof(NotifiableTestCaseSource.AddNotification_AddWithIEnumerableOfNotification_ValidParameter_ShouldAdd))]
    public void AddNotification_AddWithIEnumerableOfNotification_ValidParameter_ShouldAdd(IEnumerable<Notification> notifications)
    {
        //Arrange
        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(notifications);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.False);
            Assert.That(notifiable.Invalid, Is.True);
            Assert.That(notifiable.Notifications, Has.Count.EqualTo(notifications.Count()));

            for (int i = 0; i < notifications.Count(); i++)
            {
                Assert.That(notifiable.Notifications.ToList()[i].Property, Is.EqualTo(notifications.ToList()[i].Property));
                Assert.That(notifiable.Notifications.ToList()[i].Message, Is.EqualTo(notifications.ToList()[i].Message));
            }
        });
    }

    [Test]
    [TestCaseSource(typeof(NotifiableTestCaseSource), nameof(NotifiableTestCaseSource.AddNotification_AddWithIEnumerableOfNotification_InvalidParameter_ShouldNotAdd))]
    public void AddNotification_AddWithIEnumerableOfNotification_InvalidParameter_ShouldNotAdd(IEnumerable<Notification> notifications)
    {
        //Arrange
        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(notifications);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.True);
            Assert.That(notifiable.Invalid, Is.False);
            Assert.That(notifiable.Notifications, Is.Empty);
        });
    }

    [Test]
    [TestCaseSource(typeof(NotifiableTestCaseSource), nameof(NotifiableTestCaseSource.AddNotification_AddWithNotifiable_ValidParameter_ShouldAdd))]
    public void AddNotification_AddWithNotifiable_ValidParameter_ShouldAdd(IEnumerable<Notification> notifications)
    {
        //Arrange
        var notifiableParam = new NotifiableInherited();
        notifiableParam.AddNotification(notifications);

        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(notifiableParam);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.False);
            Assert.That(notifiable.Invalid, Is.True);
            Assert.That(notifiable.Notifications, Has.Count.EqualTo(notifiableParam.Notifications.Count));

            for (int i = 0; i < notifiable.Notifications.Count; i++)
            {
                Assert.That(notifiable.Notifications.ToList()[i].Property, Is.EqualTo(notifiableParam.Notifications.ToList()[i].Property));
                Assert.That(notifiable.Notifications.ToList()[i].Message, Is.EqualTo(notifiableParam.Notifications.ToList()[i].Message));
            }
        });
    }

    [Test]
    [TestCaseSource(typeof(NotifiableTestCaseSource), nameof(NotifiableTestCaseSource.AddNotification_AddWithNotifiable_InvalidParameter_ShouldNotAdd))]
    public void AddNotification_AddWithNotifiable_InvalidParameter_ShouldNotAdd(Notifiable notifiableParam)
    {
        //Arrange
        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(notifiableParam);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.True);
            Assert.That(notifiable.Invalid, Is.False);
            Assert.That(notifiable.Notifications, Is.Empty);
        });
    }

    [Test]
    [TestCaseSource(typeof(NotifiableTestCaseSource), nameof(NotifiableTestCaseSource.AddNotification_AddWithIEnumerableOfNotifiable_ValidParameter_ShouldAdd))]
    public void AddNotification_AddWithIEnumerableOfNotifiable_ValidParameter_ShouldAdd(IEnumerable<Notification> notifications1, IEnumerable<Notification> notifications2)
    {
        //Arrange
        var notifiable1 = new NotifiableInherited();
        notifiable1.AddNotification(notifications1);

        var notifiable2 = new NotifiableInherited();
        notifiable2.AddNotification(notifications2);

        var allNotifications = new List<Notification>();
        allNotifications.AddRange(notifications1);
        allNotifications.AddRange(notifications2);

        IEnumerable<Notifiable> notifiableList =
        [
            notifiable1,
            notifiable2
        ];

        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(notifiableList);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.False);
            Assert.That(notifiable.Invalid, Is.True);
            Assert.That(notifiable.Notifications, Has.Count.EqualTo(allNotifications.Count));

            for (int i = 0; i < notifiable.Notifications.Count; i++)
            {
                Assert.That(notifiable.Notifications.ToList()[i].Property, Is.EqualTo(allNotifications[i].Property));
                Assert.That(notifiable.Notifications.ToList()[i].Message, Is.EqualTo(allNotifications[i].Message));
            }
        });
    }

    [Test]
    [TestCaseSource(typeof(NotifiableTestCaseSource), nameof(NotifiableTestCaseSource.AddNotification_AddWithIEnumerableOfNotifiable_InvalidParameter_ShouldNotAdd))]
    public void AddNotification_AddWithIEnumerableOfNotifiable_InvalidParameter_ShouldNotAdd(IEnumerable<Notifiable> notifiableList)
    {
        //Arrange
        var notifiable = new NotifiableInherited();

        //Act
        notifiable.AddNotification(notifiableList);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.True);
            Assert.That(notifiable.Invalid, Is.False);
            Assert.That(notifiable.Notifications, Is.Empty);
        });
    }

    [Test]
    [TestCaseSource(typeof(NotifiableTestCaseSource), nameof(NotifiableTestCaseSource.ClearNotifications_ShouldClearAllNotifications))]
    public void ClearNotifications_ShouldClearAllNotifications(IEnumerable<Notification> notifications)
    {
        //Arrange
        var notifiable = new NotifiableInherited();
        notifiable.AddNotification(notifications);

        //Act
        notifiable.ClearNotifications();

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(notifiable.Valid, Is.True);
            Assert.That(notifiable.Invalid, Is.False);
            Assert.That(notifiable.Notifications, Is.Empty);
        });
    }
}

//==================================================================================================================================
//========================================================= TestCaseSource =========================================================
//==================================================================================================================================

//Class that inherits from notifiable, as its constructor is protected, so it is necessary for another class to inherit from notifiable to create an instance and use its methods.
file class NotifiableInherited : Notifiable { }

file static class NotifiableTestCaseSource
{
    public static readonly object[] AddNotification_AddWithNotification_ValidParameter_ShouldAdd =
    [
        new object[] { new Notification(null, null) },
        new object[] { new Notification(string.Empty, string.Empty) },
        new object[] { new Notification(" ", " ") },
        new object[] { new Notification("property", "message") }
    ];

    public static readonly object[] AddNotification_AddWithIEnumerableOfNotification_ValidParameter_ShouldAdd =
    [
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
            }
        },
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
            }
        },
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
                new("property-3", "message-3"),
            }
        }
    ];

    public static readonly object[] AddNotification_AddWithIEnumerableOfNotification_InvalidParameter_ShouldNotAdd =
    [
        new object[] { null },
        new object[] { new List<Notification>() }
    ];

    public static readonly object[] AddNotification_AddWithNotifiable_ValidParameter_ShouldAdd =
    [
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
            }
        },
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
            }
        },
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
                new("property-3", "message-3"),
            }
        }
    ];

    public static readonly object[] AddNotification_AddWithNotifiable_InvalidParameter_ShouldNotAdd =
    [
        new object[] { null },
        new object[] { new NotifiableInherited() }
    ];

    public static readonly object[] AddNotification_AddWithIEnumerableOfNotifiable_ValidParameter_ShouldAdd =
    [
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
            },
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
            }
        },
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
            },
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
            }
        },
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
                new("property-3", "message-3"),
            },
            new List<Notification>
            {
                new("property-1", "message-1"),
            },
        }
    ];

    public static readonly object[] AddNotification_AddWithIEnumerableOfNotifiable_InvalidParameter_ShouldNotAdd =
    [
        new object[] { null },
        new object[] { new List<Notifiable>() }
    ];

    public static readonly object[] ClearNotifications_ShouldClearAllNotifications =
    [
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
            }
        },
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
            }
        },
        new object[]
        {
            new List<Notification>
            {
                new("property-1", "message-1"),
                new("property-2", "message-2"),
                new("property-3", "message-3"),
            }
        }
    ];
}