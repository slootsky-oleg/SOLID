using System.Web.Http;
using LCP.Refactoring.Application.Notifications.Course.Commands.Activate;
using LCP.Refactoring.Application.Notifications.Course.Commands.Create;
using LCP.Refactoring.Application.Notifications.Course.Commands.Deactivate;
using LCP.Refactoring.Application.Notifications.Course.Commands.TargetAudiences;
using LCP.Refactoring.Application.Notifications.Course.Commands.Update;
using LCP.Refactoring.Application.Notifications.Course.Queries.Get;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Values;
using Unity;

namespace LCP.Refactoring.API.Controllers
{
    [RoutePrefix("api/notifications/course")]
    public class CourseNotificationController : ApiController
    {
        private readonly IUnityContainer container;

        public CourseNotificationController(IUnityContainer container)
        {
            this.container = container;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(Id id)
        {
            var interactor = container.Resolve<GetCourseNotification>();

            var notification = interactor.Execute(id);

            return Ok(notification);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(CreateCourseNotificationRequest request)
        {
            var interactor = container.Resolve<CreateCourseNotification>();

            var notification = interactor.Execute(request);

            return Ok(notification);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(Id id, UpdateCourseNotificationRequest request)
        {
            var interactor = container.Resolve<UpdateCourseNotification>();

            interactor.Execute(id, request);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}/activate")]
        public IHttpActionResult Activate(Id id)
        {
            var interactor = container.Resolve<ActivateCourseNotification>();

            interactor.Execute(id);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}/deactivate")]
        public IHttpActionResult Deactivate(Id id)
        {
            var interactor = container.Resolve<DeactivateCourseNotification>();

            interactor.Execute(id);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}/targetaudiences/{audience}")]
        public IHttpActionResult CheckTargetAudience(Id id, CourseTargetAudience audience)
        {
            var interactor = container.Resolve<CheckCourseNotificationTargetAudience>();

            interactor.Execute(id, audience);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}/targetaudiences/{audience}")]
        public IHttpActionResult UncheckTargetAudience(Id id, CourseTargetAudience audience)
        {
            var interactor = container.Resolve<CheckCourseNotificationTargetAudience>();

            interactor.Execute(id, audience);

            return Ok();
        }


    }
}