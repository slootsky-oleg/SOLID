using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;

namespace LCP.Refactoring.Application.Notifications.Course.Save
{
    public class SaveCourseNotification
    {
        private readonly ICourseNotificationRepository repository;

        public SaveCourseNotification(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(SaveCourseNotificationDto dto)
        {
            var notification = repository.Get(dto.Id) 
                               ?? throw new NotificationNotFoundException(dto.Id);

            notification.Name = dto.Name;
        }
    }
}