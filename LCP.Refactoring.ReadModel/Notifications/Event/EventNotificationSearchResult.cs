using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Entities.Notifications.Event;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.ReadModel.Notifications.Event
{
    public class EventNotificationSearchResult : INotificationSearchResult
    {
        private const string OwnerTextIdPrefix = "Notification_Event_Owner_";
        private const string TextIdPrefix = "Notification_Event_TargetAudience_";

        private readonly ITextProvider textProvider;

        public EventNotificationSearchResult(ITextProvider textProvider)
        {
            this.textProvider = textProvider;
        }

        public Id Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public EntityType EntityType => EntityType.Course;
        public string AdditionalInfo => GetAdditionalInfo();
        public string TargetAudienceText => GetTargetAudiencesInfo();
        public EventOwner EventOwner { get; set; }
        public IList<TargetAudienceItemReadModel<EventTargetAudience>> TargetAudiences { get; set; }

        private string GetAdditionalInfo()
        {
            return textProvider.Get(OwnerTextIdPrefix + EventOwner);
        }

        private string GetTargetAudiencesInfo()
        {
            var selectedItems = TargetAudiences
                .Where(a => a.IsChecked);

            return selectedItems
                .Aggregate(
                    string.Empty,
                    (current, audience) => current + GetAudienceText(audience.Value));
        }

        private string GetAudienceText(EventTargetAudience audience)
        {
            return textProvider.Get(TextIdPrefix + audience);
        }
    }
}