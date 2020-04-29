using LCP.Refactoring.Domain.Entities.Notifications.Event;

namespace LCP.Refactoring.Application.Notifications.Event.Commands.Create
{
    public class CreateEventNotificationRequest
    {
        public string Name { get; }
        public EventOwner EventOwner { get; set; }
        public bool IsActive { get; set; }
    }
}