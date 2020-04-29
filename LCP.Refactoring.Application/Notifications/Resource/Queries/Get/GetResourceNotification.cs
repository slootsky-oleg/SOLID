using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Resource.Get
{
    public class GetResourceNotification
    {
        private readonly IResourceNotificationRepository repository;

        public GetResourceNotification(IResourceNotificationRepository repository)
        {
            this.repository = repository;
        }

        public GetResourceNotificationResult Get(Id id)
        {
            var source = repository.Get(id) 
                         ?? throw new NotificationNotFoundException(id);

            return new GetResourceNotificationResult(source);
        }
    }
}