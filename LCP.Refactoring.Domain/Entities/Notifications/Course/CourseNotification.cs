using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications.Course
{
    public class CourseNotification : Notification<CourseTargetAudience>
    {
        //Once we see more logic depending on CourseType, class should be splitted farther.
        //For example: PrivateCourseNotification and CorporateCourseNotification
        private static readonly IDictionary<CourseType, IList<CourseTargetAudience>> AudiencesByType = GetAudiencesByType();

        public CourseType CourseType { get; }

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

        //Consider storing only selected items
        private static IEnumerable<CourseTargetAudienceItem> BuildTargetAudiences(CourseType courseType)
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
    }
}