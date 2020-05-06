using System.Web.Http;
using LCP.Refactoring.Application.Notifications.GenericSearch;
using Unity;

namespace LCP.Refactoring.API.Controllers
{
    [RoutePrefix("api/notifications")]
    public class SearchNotificationController : ApiController
    {
        private readonly IUnityContainer container;

        public SearchNotificationController(IUnityContainer container)
        {
            this.container = container;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Search(/*searchParameters*/)
        {
            var interactor = container.Resolve<SearchForNotifications>();

            var notification = interactor.Execute(/*searchParameters*/);

            return Ok(notification);
        }
    }
}