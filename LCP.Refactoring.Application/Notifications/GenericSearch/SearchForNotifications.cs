using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.ReadModel.Notifications;

namespace LCP.Refactoring.Application.Notifications.GenericSearch
{
    public class SearchForNotifications
    {
        private readonly INotificationReadModelStore store;

        public SearchForNotifications(INotificationReadModelStore store)
        {
            this.store = store;
        }

        public IList<INotificationSearchResult> Execute()
        {
            return store
                .Search()
                .ToList();
        }
    }
}