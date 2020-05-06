using System.Collections.Generic;

namespace LCP.Refactoring.ReadModel.Notifications
{
    public interface INotificationReadModelStore
    {
        IEnumerable<INotificationSearchResult> Search();
    }
}