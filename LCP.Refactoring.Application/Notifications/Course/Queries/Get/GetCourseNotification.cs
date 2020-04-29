using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;
using LCP.Refactoring.ReadModel.Notifications.Course;

namespace LCP.Refactoring.Application.Notifications.Course.Queries.Get
{
    public class GetCourseNotification
    {
        private readonly ICourseNotificationRepository repository;
        private readonly ICourseTargetAudienceTextBuilder targetAudienceTextBuilder;

        public GetCourseNotification(ICourseNotificationRepository repository, ICourseTargetAudienceTextBuilder targetAudienceTextBuilder)
        {
            this.repository = repository;
            this.targetAudienceTextBuilder = targetAudienceTextBuilder;
        }

        public GetCourseNotificationResponse Get(Id id)
        {
            var source = repository.Get(id) 
                         ?? throw new NotificationNotFoundException(id);

            //Use fluent builder pattern here
            return new GetCourseNotificationResponse(targetAudienceTextBuilder, source);
        }
    }
}