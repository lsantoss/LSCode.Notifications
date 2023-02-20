namespace LSCode.Notifiable
{
    /// <summary>Helps in creating notifications.</summary>
    public sealed class Notification
    {
        /// <value>Notification property.</value>
        public string Property { get; }

        /// <value>Notification message.</value>
        public string Message { get; }

        /// <summary>Notification class constructor.</summary>
        /// <param name="property">Notification property.</param>
        /// <param name="message">Notification message.</param>
        /// <returns>Create an instance of the Notification class.</returns>
        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}