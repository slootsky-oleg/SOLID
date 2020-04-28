﻿using System.Collections.Generic;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;
using LCP.Refactoring.ReadModels.Notifications;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public interface NotificationSearchResult
    {
        Id Id { get; }
        string Name { get; }
        bool IsActive { get; }
        CourseType CourseType { get; }
        EntityType EntityType { get; }
        IReadOnlyList<TargetAudienceItem<CourseTargetAudience>> TargetAudiences { get; }
        string GetTypeInfo(ITextProvider textProvider);
        string GetTargetAudiencesInfo(ITextProvider textProvider);
    }
}