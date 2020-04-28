using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.ReadModels.Notifications
{
    public interface INotificationSearchResult
    {
        Id Id { get; }
        string Name { get; }
        bool IsActive { get; }
        EntityType EntityType { get; }
        string AdditionalInfo { get; }
        string TargetAudienceText { get; }
    }
}