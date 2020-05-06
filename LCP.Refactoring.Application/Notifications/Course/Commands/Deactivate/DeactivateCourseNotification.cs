using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Course.Commands.Deactivate
{
    //It might me tempting to use the same activator/deactivator for all notification types.
    //Yet consider requirement: allow activation from specific date only for the Course notification.
    public class DeactivateCourseNotification
    {
        private readonly ICourseNotificationRepository repository;

        public DeactivateCourseNotification(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.Deactivate();

            repository.Save(notification);
        }
    }
}