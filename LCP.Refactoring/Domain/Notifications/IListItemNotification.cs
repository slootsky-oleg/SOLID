using System.Collections.Generic;
using LCP.Refactoring.Domain.Notifications.Course;
using LCP.Refactoring.Domain.Services;

namespace LCP.Refactoring.Domain.Notifications
{
    public interface IListItemNotification
    {
        long Id { get; }
        string Name { get; }
        bool IsActive { get; }
        CourseType CourseType { get; }
        EntityType EntityType { get; }
        IReadOnlyList<TargetAudience<CourseTargetAudience>> TargetAudiences { get; }
        string GetTypeInfo(ITextProvider textProvider);
        string GetTargetAudiencesInfo(ITextProvider textProvider);
    }
}