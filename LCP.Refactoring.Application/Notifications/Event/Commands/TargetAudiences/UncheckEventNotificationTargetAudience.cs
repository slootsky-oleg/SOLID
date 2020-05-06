using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Event;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Event.Commands.TargetAudiences
{
    public class UncheckEventNotificationTargetAudience
    {
        private readonly IEventNotificationRepository repository;

        public UncheckEventNotificationTargetAudience(IEventNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id, EventTargetAudience audience)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.UncheckTargetAudience(audience);

            repository.Save(notification);
        }
    }
}