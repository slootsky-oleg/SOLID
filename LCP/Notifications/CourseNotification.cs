namespace LCP.Notifications
{
    public class CourseNotification : Notification
    {
        public CourseNotification()
        {
            EntityType = EntityType.Course;
        }

        public CourseType CourseType { get; set; }
    }

    public enum CourseType
    {
        Corporate
    }
}