using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Services;

namespace LCP.Refactoring.Domain.Notifications.Course
{
    public class CourseNotification : IListItemNotification
    {
        private readonly Notification baseNotification;
        private readonly IList<TargetAudience<CourseTargetAudience>> targetAudiences;

        public long Id => baseNotification.Id;
        public string Name => baseNotification.Name;
        public bool IsActive => baseNotification.IsActive;
        public CourseType CourseType { get; }

        public EntityType EntityType => EntityType.Course;

        public IReadOnlyList<TargetAudience<CourseTargetAudience>> TargetAudiences => targetAudiences.ToList();


        public CourseNotification(long id, string name, bool isActive, CourseType courseType)
        {
            this.baseNotification = new Notification(id, name, isActive);
            CourseType = courseType;
        }

        public string GetTypeInfo(ITextProvider textProvider)
        {
            const string textIdPrefix = "Notification_CourseType_";
            return textProvider.Get(textIdPrefix + CourseType);
        }
        public string GetTargetAudiencesInfo(ITextProvider textProvider)
        {
            const string textIdPrefix = "Notification_CourseType_TargetAudience_";

            var selectedAudiences = targetAudiences
                .Where(a => a.IsSelected);

            return selectedAudiences
                .Aggregate(
                    string.Empty, 
                    (current, audience) => current + textProvider.Get(textIdPrefix + audience.Value));
        }
    }
}