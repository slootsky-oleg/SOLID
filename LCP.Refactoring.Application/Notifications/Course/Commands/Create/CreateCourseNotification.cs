using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Repositories;
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

        public Id Execute(CreateCourseNotificationRequest request)
        {
            var notification = new CourseNotification(request.Name, request.IsActive, request.CourseType);

            repository.Save(notification);

            return notification.Id;
        }
    }
}