namespace LCP.Refactoring.Domain.Notifications.Course
{
    public interface ICourseNotificationRepository
    {
        CourseNotification Get(long id);
        long Save(CourseNotification notification);
    }
}