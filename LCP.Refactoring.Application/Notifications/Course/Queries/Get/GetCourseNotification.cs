using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

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

        public GetCourseNotificationResponse Get(Id id)
        {
            var source = repository.Get(id) 
                         ?? throw new NotificationNotFoundException(id);

            return new GetCourseNotificationResponse(textProvider, source);
        }
    }
}