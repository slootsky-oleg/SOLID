using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.ReadModels.Notifications.Course
{
    public class CourseNotificationSearchResult : INotificationSearchResult
    {
        private const string CourseTextIdPrefix = "Notification_Course_CourseType_";
        private const string TextIdPrefix = "Notification_Course_TargetAudience_";
        private const string TextParticipant = "Notification_Course_TargetAudience_Participant";

        private readonly ITextProvider textProvider;

        public CourseNotificationSearchResult(ITextProvider textProvider)
        {
            this.textProvider = textProvider;
        }

        public Id Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public EntityType EntityType => EntityType.Course;
        public string AdditionalInfo => GetAdditionalInfo();
        public string TargetAudienceText => GetTargetAudiencesInfo();
        public CourseType CourseType { get; set; }
        public IList<TargetAudienceItemReadModel<CourseTargetAudience>> TargetAudiences { get; set; }

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
                    (current, audience) => current + GetAudienceText(audience.Value));
        }

        private string GetAudienceText(CourseTargetAudience audience)
        {
            if (CourseType == CourseType.Corporate && audience == CourseTargetAudience.User)
            {
                return textProvider.Get(TextParticipant);
            }

            return textProvider.Get(TextIdPrefix + audience);
        }
    }
}