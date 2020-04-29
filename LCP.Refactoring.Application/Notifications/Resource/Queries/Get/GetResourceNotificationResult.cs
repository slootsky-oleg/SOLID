using LCP.Refactoring.Domain.Entities.Notifications.Resource;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Resource.Queries.Get
{
    public class GetResourceNotificationResult
    {
        public Id Id { get; }
        public string Name { get; }

        public GetResourceNotificationResult(ResourceNotification source)
        {
            Id = source.Id;
            Name = source.Name;
        }
    }
}