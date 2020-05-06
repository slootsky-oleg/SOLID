using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.ReadModel.Notifications.Resource
{
    public class ResourceNotificationSearchResult : INotificationSearchResult
    {
        public Id Id { get; }
        public string Name { get; }
        public bool IsActive { get; }
        public EntityType EntityType => EntityType.Resource;
        public string AdditionalInfo => string.Empty;
        public string TargetAudienceText => string.Empty;
        public CourseType CourseType { get; set; }
    }
}