using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Course.TargetAudiences
{
    public class CheckCourseNotificationTargetAudience
    {
        private readonly ICourseNotificationRepository repository;

        public CheckCourseNotificationTargetAudience(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id, CourseTargetAudience audience)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.CheckTargetAudience(audience);

            repository.Save(notification);
        }
    }
}