using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Event;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Event.Queries.Get
{
    public class GetEventNotificationResponse
    {
        private readonly ITextProvider textProvider;

        public Id Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public EventOwner EventOwner { get; }
        public IList<TargetAudienceDto<EventTargetAudience>> TargetAudiences { get; set; }

        public GetEventNotificationResponse(ITextProvider textProvider, EventNotification source)
        {
            this.textProvider = textProvider;

            Id = source.Id;
            Name = source.Name;
            Active = source.IsActive;
            EventOwner = source.EventOwner;
            TargetAudiences = source
                .TargetAudiences
                .Select(BuildTargetAudience)
                .ToList();
        }

        private TargetAudienceDto<EventTargetAudience> BuildTargetAudience(TargetAudienceItem<EventTargetAudience> audienceItem)
        {
            var valueText = textProvider.Get($"Notification_Event_TargetAudience_{audienceItem.Value}");
            return new TargetAudienceDto<EventTargetAudience>(audienceItem, valueText);
        }
    }
}