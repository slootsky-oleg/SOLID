using System;

namespace LCP.Refactoring.Domain.Entities.Notifications.Course
{
    public class InvalidCourseTargetAudience : Exception
    {
        public CourseType CourseType { get; }
        public CourseTargetAudience Audience { get; }

        public InvalidCourseTargetAudience(CourseType courseType, CourseTargetAudience audience)
            : base($"Audience [{audience}] incompatible with with [{courseType}] course.")
        {
            CourseType = courseType;
            Audience = audience;
        }
    }
}