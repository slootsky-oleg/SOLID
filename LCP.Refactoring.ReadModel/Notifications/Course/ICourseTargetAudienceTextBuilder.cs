using LCP.Refactoring.Domain.Entities.Notifications.Course;

namespace LCP.Refactoring.ReadModel.Notifications.Course
{
    public interface ICourseTargetAudienceTextBuilder
    {
        string Build(CourseTargetAudience audience);
    }
}