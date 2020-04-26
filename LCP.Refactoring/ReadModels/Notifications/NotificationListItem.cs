using LCP.Refactoring.Domain.Notifications;

namespace LCP.Refactoring.ReadModels.Notifications
{
    public class NotificationListItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public EntityType EntityType { get; set; }
        public string AdditionalInfo { get; set; }
    }
}