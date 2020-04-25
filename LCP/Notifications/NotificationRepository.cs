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
    }
}