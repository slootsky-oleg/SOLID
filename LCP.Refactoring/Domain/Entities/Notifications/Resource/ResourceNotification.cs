using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications.Course
{
    public class ResourceNotification// : NotificationSearchResult
    {
        private readonly Notification<int> baseNotification;

        public Id Id => baseNotification.Id;

        public string Name
        {
            get => baseNotification.Name;
            set => baseNotification.Name = value;
        }

        //Hide active
        //public bool IsActive => baseNotification.IsActive;

        public EntityType EntityType => EntityType.Resource;

        public ResourceNotification(string name)
        {
            var emptyTargetAudiences = new List<TargetAudienceItem<int>>();
            this.baseNotification = new Notification(name, true, emptyTargetAudiences);
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

        public ResourceNotification(Id id, string name, bool isActive, CourseType courseType)
            : this(courseType)
        {
            this.baseNotification = new Notification(id, name, isActive);
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
            var item = GetTargetAudience(audience);
            item.Check();
        }

        public void UncheckTargetAudience(CourseTargetAudience audience)
        {
            var item = GetTargetAudience(audience);
            item.Uncheck();
        }

        private CourseTargetAudienceItem GetTargetAudience(CourseTargetAudience audience)
        {
            return targetAudiences.Single(a => a.Value == audience);
        }
    }
}