using System.Collections.Generic;
using LCP.Refactoring.Application.Notifications.GenericSearch;

namespace LCP.Refactoring.ReadModels.Notifications
{
    public interface INotificationReadModelStore
    {
        IEnumerable<INotificationSearchResult> Search();
    }
}