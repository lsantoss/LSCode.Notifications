using System.Collections.Generic;
using System.Linq;

namespace LSCode.Notifications.Models
{
    /// <summary>Helps in managing notifications.</summary>
    public class Notifiable
    {
        /// <value>Indicates if it is valid.</value>
        public bool Valid => Notifications.Any() == false;

        /// <value>Indicates if it is invalid.</value>
        public bool Invalid => Notifications.Any() == true;

        /// <value>List of notifications.</value>
        public IReadOnlyCollection<Notification> Notifications => _notifications.ToList();
        private readonly List<Notification> _notifications;

        /// <summary>Notifiable class constructor.</summary>
        /// <returns>Creates an instance of the Notifiable class.</returns>
        protected Notifiable() => _notifications = new List<Notification>();

        /// <summary>Add a notification.</summary>
        /// <param name="property">Notification property.</param>
        /// <param name="message">Notification message.</param>
        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

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
                _notifications.AddRange(notifications?.Where(notification => notification != null));
        }

        /// <summary>Adds notifications present in a Notifiable.</summary>
        /// <remarks>Null notifications will not be added to the list.</remarks>
        /// <param name="notifiable">Notifiable.</param>
        public void AddNotification(Notifiable notifiable)
        {
            if (notifiable != null && notifiable.Notifications != null)
                _notifications.AddRange(notifiable.Notifications.Where(notification => notification != null));
        }

        /// <summary>Adds notifications present in a list of Notifiable.</summary>
        /// <remarks>Null notifications will not be added to the list.</remarks>
        /// <param name="notifiableList">List of Notifiable.</param>
        public void AddNotification(IEnumerable<Notifiable> notifiableList)
        {
            if (notifiableList != null)
                foreach (var notifiable in notifiableList.Where(notifiable => notifiable != null && notifiable.Notifications != null))
                    _notifications.AddRange(notifiable.Notifications.Where(notification => notification != null));
        }

        /// <summary>Clear the list of notifications.</summary>
        public void Clear() => _notifications.Clear();
    }
}