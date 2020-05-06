using System.Collections.Generic;

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

        public void Save(Notification notification)
        {
            //DAL logic here
            //if (notification.IsCourseNotification)
            //if (notification.IsResourceNotification)
            //...
        }
    }
}