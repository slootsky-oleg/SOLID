using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace LCP.Notifications
{
    public class NotificationRepository
    {
        private string connectionString;

        public NotificationRepository()
        {
            //connectionString = SystemSettings.Get("Db_Connection_String");
        }

        public IEnumerable<Notification> GetAll()
        {
            //DAL logic here
            return new List<Notification>();
        }

        public Notification Get(long id)
        {
            //DAL logic here
            //return new CourseNotification();
            //return new ResourceNotification();
            //...
            return null;
        }
    }
}