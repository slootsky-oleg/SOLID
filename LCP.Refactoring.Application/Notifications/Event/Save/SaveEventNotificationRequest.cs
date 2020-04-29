using LCP.Refactoring.Domain.Entities.Notifications.Event;

namespace LCP.Refactoring.Application.Notifications.Event.Save
{
    public class SaveEventNotificationRequest
    {
        public string Name { get; }
        public EventOwner EventOwner { get; set; }
    }
}