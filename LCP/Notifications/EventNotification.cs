namespace LCP.Notifications
{
    public class EventNotification : Notification
    {
        public EventOwner EventOwner { get; set; }
    }

    public enum EventOwner
    {
        Course,
        User
    }
}