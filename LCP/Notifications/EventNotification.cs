namespace LCP.Notifications
{
    public class EventNotification : Notification
    {
        public EventNotification()
        {
            EntityType = EntityType.Event;
        }

        public EventOwner EventOwner { get; set; }
    }

    public enum EventOwner
    {
        Course,
        User
    }
}