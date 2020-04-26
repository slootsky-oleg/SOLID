using LCP.Refactoring.Domain.Notifications;
using LCP.Refactoring.Domain.Notifications.Course;
using LCP.Refactoring.Domain.Services;

namespace LCP.Refactoring.Application.Notifications.Course.Get
{
    public class GetCourseNotification
    {
        private readonly ICourseNotificationRepository repository;
        private readonly ITextProvider textProvider;

        public GetCourseNotification(ICourseNotificationRepository repository, ITextProvider textProvider)
        {
            this.repository = repository;
            this.textProvider = textProvider;
        }

        public CourseNotificationDto Get(long id)
        {
            var source = repository.Get(id) 
                         ?? throw new NotificationNotFoundException(id);

            return new CourseNotificationDto(textProvider, source);
        }
    }
}