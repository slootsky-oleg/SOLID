using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;

namespace LCP.Refactoring.Application.Notifications.Course.TargetAudiences
{
    public class UncheckCourseNotificationTargetAudience
    {
        private readonly ICourseNotificationRepository repository;

        public UncheckCourseNotificationTargetAudience(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(long id, CourseTargetAudience audience)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.UncheckTargetAudience(audience);

            repository.Save(notification);
        }
    }
}