using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Services;

namespace LCP.Refactoring.Application.Notifications.Course.Get
{
    public class TargetAudienceTextBuilder
    {
        private readonly ITextProvider textProvider;
        private readonly CourseNotification notification;

        //TODO: use in readmodel

        public TargetAudienceTextBuilder(ITextProvider textProvider, CourseNotification notification)
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