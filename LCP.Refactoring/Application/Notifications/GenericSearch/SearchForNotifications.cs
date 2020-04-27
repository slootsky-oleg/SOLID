using LCP.Refactoring.Domain.Entities.Notifications;
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

        public NotificationSearchResult Execute()
        {
            var notifications = store.Search();
        }
    }
}