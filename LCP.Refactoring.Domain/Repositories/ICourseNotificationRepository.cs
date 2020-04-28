using LCP.Refactoring.Domain.Entities.Notifications.Course;

namespace LCP.Refactoring.Domain.Repositories
{
    public interface ICourseNotificationRepository
    {
        CourseNotification Get(long id);
        long Save(CourseNotification notification);
    }
}