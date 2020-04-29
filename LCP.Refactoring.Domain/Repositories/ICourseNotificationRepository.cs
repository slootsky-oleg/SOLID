using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Repositories
{
    public interface ICourseNotificationRepository
    {
        CourseNotification Get(Id id);
        long Save(CourseNotification notification);
    }
}