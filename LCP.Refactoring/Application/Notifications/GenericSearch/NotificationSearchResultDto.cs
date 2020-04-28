using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Values;
using LCP.Refactoring.ReadModels.Notifications;

namespace LCP.Refactoring.Application.Notifications.GenericSearch
{
    public class NotificationSearchResultDto
    {
        public Id Id { get; }
        public string Name { get; }
        public bool IsActive { get; }
        public EntityType EntityType { get; }
        public string AdditionalInfo { get; }
        public string TargetAudienceText { get; }

        public NotificationSearchResultDto(INotificationSearchResult source)
        {
            Id = source.Id;
            Name = source.Name;
            IsActive = source.IsActive;
            EntityType = source.EntityType;
            AdditionalInfo = source.AdditionalInfo;
            TargetAudienceText = source.TargetAudienceText;
        }
    }
}