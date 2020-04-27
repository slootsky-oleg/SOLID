using System.Collections.Generic;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public interface INotificationRepository
    {
        IEnumerable<IListItemNotification> GetAll();
    }
}