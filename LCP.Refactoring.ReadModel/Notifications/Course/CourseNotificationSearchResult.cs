using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.ReadModel.Notifications.Course
{
    public class CourseNotificationSearchResult : INotificationSearchResult
    {
        private const string CourseTextIdPrefix = "Notification_Course_CourseType_";
        private const string TextIdPrefix = "Notification_Course_TargetAudience_";
        private const string TextParticipant = "Notification_Course_TargetAudience_Participant";

        private readonly ICourseTargetAudienceTextBuilder audienceTextBuilder;
        private readonly ITextProvider textProvider;

        public Id Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public EntityType EntityType => EntityType.Course;
        public string AdditionalInfo => GetAdditionalInfo();
        public string TargetAudienceText => GetTargetAudiencesInfo();
        public CourseType CourseType { get; set; }
        public IList<TargetAudienceItemReadModel<CourseTargetAudience>> TargetAudiences { get; set; }

        public CourseNotificationSearchResult(
            ICourseTargetAudienceTextBuilder audienceTextBuilder,
            ITextProvider textProvider)
        {
            this.audienceTextBuilder = audienceTextBuilder;
            this.textProvider = textProvider;
        }

        private string GetAdditionalInfo()
        {
            return textProvider.Get(CourseTextIdPrefix + CourseType);
        }

        private string GetTargetAudiencesInfo()
        {
            var selectedItems = TargetAudiences
                .Where(a => a.IsChecked);

            return selectedItems
                .Aggregate(
                    string.Empty,
                    (current, audience) => current + audienceTextBuilder.Build(audience.Value));
        }
    }
}