﻿using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Course.Queries.Get
{
    public class GetCourseNotificationResponse
    {
        private readonly ITargetAudienceTextBuilder audienceTextBuilder;

        public Id Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public CourseType CourseType { get; }
        public IList<TargetAudienceDto<CourseTargetAudience>> TargetAudiences { get; set; }

        public GetCourseNotificationResponse(ITargetAudienceTextBuilder<CourseTargetAudience> audienceTextBuilder, CourseNotification source)
        {
            this.audienceTextBuilder = audienceTextBuilder;

            Id = source.Id;
            Name = source.Name;
            Active = source.IsActive;
            CourseType = source.CourseType;
            TargetAudiences = source
                .TargetAudiences
                .Select(BuildTargetAudience)
                .ToList();
        }

        private TargetAudienceDto<CourseTargetAudience> BuildTargetAudience(TargetAudienceItem<CourseTargetAudience> audienceItem)
        {
            var valueText = audienceTextBuilder.Build(audienceItem.Value);

            return new TargetAudienceDto<CourseTargetAudience>(audienceItem, valueText);
        }
    }
}