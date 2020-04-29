using LCP.Refactoring.Domain.Entities.Notifications;

namespace LCP.Refactoring.Application.Notifications.Course.Commands.Create
{
    public class CreateCourseNotificationRequest
    {
        public string Name { get; }
        public CourseType CourseType { get; set; }
        public bool IsActive { get; set; }
    }
}