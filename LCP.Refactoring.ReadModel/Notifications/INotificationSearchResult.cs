using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.ReadModel.Notifications
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