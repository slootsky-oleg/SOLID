using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Event.Commands.Update
{
    public class SaveEventNotification
    {
        private readonly IEventNotificationRepository repository;

        public SaveEventNotification(IEventNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id, SaveEventNotificationRequest request)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.Name = request.Name;
            notification.EventOwner = request.EventOwner;
        }
    }
}