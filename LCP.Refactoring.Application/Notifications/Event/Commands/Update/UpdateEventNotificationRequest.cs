using LCP.Refactoring.Domain.Entities.Notifications.Event;

namespace LCP.Refactoring.Application.Notifications.Event.Commands.Update
{
    public class SaveEventNotificationRequest
    {
        public string Name { get; }
        public EventOwner EventOwner { get; set; }
    }
}