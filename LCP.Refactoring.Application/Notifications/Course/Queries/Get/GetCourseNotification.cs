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

        public GetCourseNotificationResponse Execute(Id id)
        {
            var source = repository.Get(id) 
                         ?? throw new NotificationNotFoundException(id);

            //1.Use fluent builder pattern here
            //  new GetCourseNotificationResponseBuilder(targetAudienceTextBuilder).Build()
            //2. Use read model store to produce response ignoring Notification entity
            return new GetCourseNotificationResponse(targetAudienceTextBuilder, source);
        }
    }
}