using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Course.Create
{
    public class CreateCourseNotification
    {
        private readonly ICourseNotificationRepository repository;

        public CreateCourseNotification(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public Id Execute(CreateCourseNotificationDto dto)
        {
            var notification = new CourseNotification(dto.Name, dto.IsActive, dto.CourseType);

            repository.Save(notification);

            return notification.Id;
        }
    }
}