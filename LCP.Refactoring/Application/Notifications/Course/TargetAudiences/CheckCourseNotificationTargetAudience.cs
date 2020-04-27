using LCP.Refactoring.Domain.Notifications;
using LCP.Refactoring.Domain.Notifications.Course;

namespace LCP.Refactoring.Application.Notifications.Course.TargetAudiences
{
    public class CheckCourseNotificationTargetAudience
    {
        private readonly ICourseNotificationRepository repository;

        public CheckCourseNotificationTargetAudience(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(long id, CourseTargetAudience audience)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.CheckTargetAudience(audience);

            repository.Save(notification);
        }
    }
}