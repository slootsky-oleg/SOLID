namespace LCP.Refactoring.Domain.Entities.Notifications.Course
{
    public interface ICourseNotificationRepository
    {
        CourseNotification Get(long id);
        long Save(CourseNotification notification);
    }
}