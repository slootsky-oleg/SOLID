using System.Collections.Generic;

namespace LCP.Refactoring.ReadModels.Notifications
{
    public interface INotificationReadModelStore
    {
        IEnumerable<NotificationListItem> GetAll();
    }
}