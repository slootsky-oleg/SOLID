using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Services;

namespace LCP.Refactoring.Domain.Notifications.Course
{
    public class CourseNotification : IListItemNotification
    {
        private readonly Notification baseNotification;

        //Consider using HashSet if order is not required
        private readonly IList<TargetAudience<CourseTargetAudience>> targetAudiences;

        public long Id => baseNotification.Id;
        public string Name
        {
            get => baseNotification.Name;
            set => baseNotification.Name = value;
        } 
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
                .Where(a => a.IsChecked);

            return selectedAudiences
                .Aggregate(
                    string.Empty, 
                    (current, audience) => current + textProvider.Get(textIdPrefix + audience.Value));
        }

        public void Activate()
        {
            baseNotification.IsActive = true;
        }

        public void Deactivate()
        {
            baseNotification.IsActive = false;
        }

        public void CheckTargetAudience(CourseTargetAudience audience)
        {
            if (CourseType == CourseType.Scheduling 
                && audience == CourseTargetAudience.Manager)
            {
                throw new InvalidCourseTargetAudience(CourseType, audience);
            }

            var item = GetTargetAudience(audience);
            item.Check();
        }

        public void UncheckTargetAudience(CourseTargetAudience audience)
        {
            var item = GetTargetAudience(audience);
            item.Uncheck();
        }

        private TargetAudience<CourseTargetAudience> GetTargetAudience(CourseTargetAudience audience)
        {
            return targetAudiences.Single(a => a.Value == audience);
        }
    }
}