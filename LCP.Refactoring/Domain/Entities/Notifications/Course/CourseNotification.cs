using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications.Course
{
    public class CourseNotification : Notification<CourseTargetAudience>
    {
        private static readonly IDictionary<CourseType, IList<CourseTargetAudience>> AudiencesByType = GetAudiencesByType();

        public CourseType CourseType { get; }

        public EntityType EntityType => EntityType.Course;

        public CourseNotification(string name, bool isActive, CourseType courseType) 
            : base(name, isActive, BuildTargetAudiences(courseType))
        {
            CourseType = courseType;
        }


        public CourseNotification(Id id, string name, bool isActive, CourseType courseType)
            : base(id, name, isActive, BuildTargetAudiences(courseType))
        {
            CourseType = courseType;
        }

        private static IList<CourseTargetAudienceItem> BuildTargetAudiences(CourseType courseType)
        {
            var courseAudiences = AudiencesByType[courseType];
            return courseAudiences
                .Select(a => new CourseTargetAudienceItem(a))
                .ToList();
        }

        private static Dictionary<CourseType, IList<CourseTargetAudience>> GetAudiencesByType()
        {
            return new
                Dictionary<CourseType, IList<CourseTargetAudience>>
                {
                    {
                        CourseType.Private,
                        new List<CourseTargetAudience> {CourseTargetAudience.User}
                    },
                    {
                        CourseType.Corporate,
                        new List<CourseTargetAudience>
                        {
                            CourseTargetAudience.User,
                            CourseTargetAudience.Manager
                        }
                    },
                };
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
                .Where(a => a.IsChecked);

            return selectedAudiences
                .Aggregate(
                    string.Empty, 
                    (current, audience) => current + textProvider.Get(textIdPrefix + audience.Value));
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}