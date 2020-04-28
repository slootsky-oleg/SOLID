using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.ReadModels.Notifications;

namespace LCP.Refactoring.Application.Notifications.GenericSearch
{
    public class SearchForNotifications
    {
        private readonly INotificationReadModelStore store;

        public SearchForNotifications(INotificationReadModelStore store)
        {
            this.store = store;
        }

        public IList<NotificationSearchResultDto> Execute()
        {
            var notifications = store.Search();

            return notifications
                .Select(n => new NotificationSearchResultDto(n))
                .ToList();
        }
    }
}