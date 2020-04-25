namespace LCP.Notifications
{
    public class CourseNotification : Notification
    {
        public CourseType CourseType { get; set; }
    }

    public enum CourseType
    {
        Scheduling
    }
}