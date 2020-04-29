using LCP.Refactoring.Domain.Entities.Notifications.Resource;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Resource.Create
{
    public class CreateResourceNotification
    {
        private readonly IResourceNotificationRepository repository;

        public CreateResourceNotification(IResourceNotificationRepository repository)
        {
            this.repository = repository;
        }

        public Id Execute(CreateResourceNotificationRequest request)
        {
            var notification = new ResourceNotification(request.Name);

            repository.Save(notification);

            return notification.Id;
        }
    }
}