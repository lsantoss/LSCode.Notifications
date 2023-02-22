using System.Collections.Generic;
using System.Linq;

namespace LSCode.Notifications.Models
{
    /// <summary>Helps in managing notifications.</summary>
    public class Notifiable
    {
        /// <value>Indicates if it is valid.</value>
        public bool Valid { get; private set; }

        /// <value>Indicates if it is invalid.</value>
        public bool Invalid { get; private set; }

        /// <value>List of notifications.</value>
        public IReadOnlyCollection<Notification> Notifications => _notifications.ToList();
        private readonly IList<Notification> _notifications;

        /// <summary>Notifiable class constructor.</summary>
        /// <returns>Creates an instance of the Notifiable class.</returns>
        protected Notifiable()
        {
            _notifications = new List<Notification>();
            Invalid = false;
            Valid = true;
        }

        /// <summary>Add a notification.</summary>
        /// <param name="property">Notification property.</param>
        /// <param name="message">Notification message.</param>
        public void AddNotification(string property, string message)
        {
            Invalidate();

            _notifications.Add(new Notification(property, message));
        }

        /// <summary>Add a notification.</summary>
        /// <param name="notification">Notification.</param>
        public void AddNotification(Notification notification)
        {
            Invalidate();

            _notifications.Add(notification);
        }

        /// <summary>Add a notification list.</summary>
        /// <param name="notifications">List of notifications.</param>
        public void AddNotification(IEnumerable<Notification> notifications)
        {
            Invalidate();

            if (notifications != null && notifications.Count() > 0)
                foreach (var notification in notifications)
                    _notifications.Add(notification);
        }

        /// <summary>Adds notifications present in a Notifiable.</summary>
        /// <param name="notifiable">Notifiable.</param>
        public void AddNotification(Notifiable notifiable)
        {
            Invalidate();

            if (notifiable != null && notifiable.Notifications != null && notifiable.Notifications.Count > 0)
                foreach (var notification in notifiable.Notifications)
                    _notifications.Add(notification);
        }

        /// <summary>Adds notifications present in a list of Notifiable.</summary>
        /// <param name="notifiableList">List of Notifiable.</param>
        public void AddNotification(IEnumerable<Notifiable> notifiableList)
        {
            Invalidate();

            if (notifiableList != null && notifiableList.Count() > 0)
                foreach (var notifier in notifiableList)
                    if (notifier != null && notifier.Notifications.Count > 0)
                        foreach (var notification in notifier.Notifications)
                            _notifications.Add(notification);
        }

        /// <summary>Invalidate the instance, setting True for the Invalid property and False for the Valid property.</summary>
        private void Invalidate()
        {
            Valid = false;
            Invalid = true;
        }
    }
}