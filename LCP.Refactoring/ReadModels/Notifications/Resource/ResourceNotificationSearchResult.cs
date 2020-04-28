using System;
using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.ReadModels.Notifications.Course
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