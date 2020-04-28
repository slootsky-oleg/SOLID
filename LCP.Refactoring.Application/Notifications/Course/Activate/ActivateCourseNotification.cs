using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;

namespace LCP.Refactoring.Application.Notifications.Course.Activate
{
    //It might me tempting to use the same activator/deactivator for all notification types.
    //Yet consider requirement: allow activation from specific date only for the Course notification.
    public class ActivateCourseNotification
    {
        private readonly ICourseNotificationRepository repository;

        public ActivateCourseNotification(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(long id)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.Activate();

            repository.Save(notification);
        }
    }
}