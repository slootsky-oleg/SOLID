using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Services;

namespace LCP.Refactoring.Application.Notifications.Course
{
    public class CourseTargetAudienceTextBuilder
    {
        private readonly ITextProvider textProvider;
        private readonly CourseNotification notification;

        public CourseTargetAudienceTextBuilder(ITextProvider textProvider, CourseNotification notification)
        {
            this.textProvider = textProvider;
            this.notification = notification;
        }

        public string Build(CourseTargetAudience audience)
        {
            if (notification.CourseType == CourseType.Private && audience == CourseTargetAudience.User)
            {
                return textProvider.Get("Course_Notification_TargetAudience_Participant");
            }

            return textProvider.Get($"Course_Notification_TargetAudience_{audience}");
        }
    }
}