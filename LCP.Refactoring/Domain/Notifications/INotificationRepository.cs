using System.Collections.Generic;
using LCP.Refactoring.Domain.Notifications.Course;

namespace LCP.Refactoring.Domain.Notifications
{
    public interface INotificationRepository
    {
        IEnumerable<IListItemNotification> GetAll();
    }
}