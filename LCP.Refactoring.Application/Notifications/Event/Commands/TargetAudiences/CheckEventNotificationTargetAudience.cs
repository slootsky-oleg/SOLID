using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Event;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Event.Commands.TargetAudiences
{
    public class CheckEventNotificationTargetAudience
    {
        private readonly IEventNotificationRepository repository;

        public CheckEventNotificationTargetAudience(IEventNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id, EventTargetAudience audience)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.CheckTargetAudience(audience);

            repository.Save(notification);
        }
    }
}