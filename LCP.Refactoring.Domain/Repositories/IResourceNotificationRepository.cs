using LCP.Refactoring.Domain.Entities.Notifications.Resource;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Repositories
{
    public interface IResourceNotificationRepository
    {
        ResourceNotification Get(Id id);
        long Save(ResourceNotification notification);
    }
}