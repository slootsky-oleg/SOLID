using LCP.Refactoring.Domain.Entities.Notifications;

namespace LCP.Refactoring.Application.Notifications.Course.Create
{
    public class CreateCourseNotificationDto
    {
        public string Name { get; }
        public CourseType CourseType { get; set; }
        public bool IsActive { get; set; }
    }
}