using LCP.Refactoring.Domain.Entities.Notifications.Event;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Repositories
{
    public interface IEventNotificationRepository
    {
        EventNotification Get(Id id);
        long Save(EventNotification notification);
    }
}