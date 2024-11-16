using LSCode.Notifications.Models;

namespace LSCode.Notifications.Test.Unit.Models.TestCaseSources;

internal static class NotifiableTestCaseSource
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


//Class that inherits from notifiable, as its constructor is protected, so it is necessary for another class to inherit from notifiable to create an instance and use its methods.
internal class NotifiableInherited : Notifiable { }