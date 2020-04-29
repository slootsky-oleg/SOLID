using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Resource.Save
{
    public class SaveResourceNotification
    {
        private readonly IResourceNotificationRepository repository;

        public SaveResourceNotification(IResourceNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id, SaveResourceNotificationRequest request)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.Name = request.Name;
        }
    }
}