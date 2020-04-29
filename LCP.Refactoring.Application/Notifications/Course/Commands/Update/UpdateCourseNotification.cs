using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Course.Save
{
    public class SaveCourseNotification
    {
        private readonly ICourseNotificationRepository repository;

        public SaveCourseNotification(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id, SaveCourseNotificationRequest request)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.Name = request.Name;
        }
    }
}