
namespace LCP.Notifications
{
    public class ResourceNotification : Notification
    {
        public ResourceType ResourceType { get; set; }
    }

    public enum ResourceType
    {
        Human,
        Physical
    }
}