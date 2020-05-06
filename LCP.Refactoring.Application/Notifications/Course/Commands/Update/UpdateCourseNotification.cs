using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Course.Commands.Update
{
    public class UpdateCourseNotification
    {
        private readonly ICourseNotificationRepository repository;

        public UpdateCourseNotification(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id, UpdateCourseNotificationRequest request)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.Name = request.Name;
        }
    }
}