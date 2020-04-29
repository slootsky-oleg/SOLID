using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Event.Get
{
    public class GetEventNotification
    {
        private readonly IEventNotificationRepository repository;
        private readonly ITextProvider textProvider;

        public GetEventNotification(IEventNotificationRepository repository, ITextProvider textProvider)
        {
            this.repository = repository;
            this.textProvider = textProvider;
        }

        public GetEventNotificationResponse Get(Id id)
        {
            var source = repository.Get(id) 
                         ?? throw new NotificationNotFoundException(id);

            return new GetEventNotificationResponse(textProvider, source);
        }
    }
}