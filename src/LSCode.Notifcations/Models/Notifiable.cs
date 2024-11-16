namespace LSCode.Notifications.Models;

/// <summary>Helps in managing notifications.</summary>
public class Notifiable
{
    /// <value>Indicates if it is valid.</value>
    public bool Valid => Notifications.Count == 0;

    /// <value>Indicates if it is invalid.</value>
    public bool Invalid => !Valid;

    /// <value>List of notifications.</value>
    public IReadOnlyCollection<Notification> Notifications => [.. _notifications];
    private readonly List<Notification> _notifications = [];

    /// <summary>Notifiable class constructor.</summary>
    /// <returns>Creates an instance of the Notifiable class.</returns>
    protected Notifiable() { }

    /// <summary>Add a notification.</summary>
    /// <param name="property">Notification property.</param>
    /// <param name="message">Notification message.</param>
    public void AddNotification(string property, string message) => _notifications.Add(new(property, message));

    /// <summary>Add a notification.</summary>
    /// <remarks>Null notifications will not be added to the list.</remarks>
    /// <param name="notification">Notification.</param>
    public void AddNotification(Notification notification)
    {
        if (notification != null)
            _notifications.Add(notification);
    }

    /// <summary>Add a notification list.</summary>
    /// <remarks>Null notifications will not be added to the list.</remarks>
    /// <param name="notifications">List of notifications.</param>
    public void AddNotification(IEnumerable<Notification> notifications)
    {
        if (notifications != null)
        {
            var listToAdd = notifications.Where(notification => notification != null);
            _notifications.AddRange(listToAdd);
        }
    }

    /// <summary>Adds notifications present in a Notifiable.</summary>
    /// <remarks>Null notifications will not be added to the list.</remarks>
    /// <param name="notifiable">Notifiable.</param>
    public void AddNotification(Notifiable notifiable)
    {
        if (notifiable != null && notifiable.Notifications != null)
        {
            var listToAdd = notifiable.Notifications.Where(notification => notification != null);
            _notifications.AddRange(listToAdd);
        }
    }

    /// <summary>Adds notifications present in a list of Notifiable.</summary>
    /// <remarks>Null notifications will not be added to the list.</remarks>
    /// <param name="notifiableList">List of Notifiable.</param>
    public void AddNotification(IEnumerable<Notifiable> notifiableList)
    {
        if (notifiableList != null)
        {
            foreach (var notifiable in notifiableList)
            {
                if (notifiable != null && notifiable.Notifications != null)
                {
                    var listToAdd = notifiable.Notifications.Where(notification => notification != null);
                    _notifications.AddRange(listToAdd);
                }
            }
        }
    }

    /// <summary>Clear the list of notifications.</summary>
    public void Clear() => _notifications.Clear();
}