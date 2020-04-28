using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Course.Get
{
    public class GetCourseNotificationDto
    {
        private readonly CourseTargetAudienceTextBuilder audienceTextBuilder;

        public Id Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public CourseType CourseType { get; }
        public IList<TargetAudienceDto<CourseTargetAudience>> TargetAudiences;

        public GetCourseNotificationDto(ITextProvider textProvider, CourseNotification source)
        {
            this.audienceTextBuilder = new CourseTargetAudienceTextBuilder(textProvider, source);

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