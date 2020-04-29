using LCP.Refactoring.Domain.Entities.Notifications.Event;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Event.Commands.Create
{
    public class CreateEventNotification
    {
        private readonly IEventNotificationRepository repository;

        public CreateEventNotification(IEventNotificationRepository repository)
        {
            this.repository = repository;
        }

        public Id Execute(CreateEventNotificationRequest request)
        {
            var notification = new EventNotification(request.Name, request.IsActive, request.EventOwner);

            repository.Save(notification);

            return notification.Id;
        }
    }
}