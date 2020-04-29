using System;

namespace LCP.Notifications
{
    public abstract class Notification
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public bool Active { get; set; }
        public EntityType EntityType { get; set; }
        public TargetAudience TargetAudience { get; set; }

        public bool IsResourceNotification => EntityType == EntityType.Resource;
        public bool IsCourseNotification => EntityType == EntityType.Course;
        public bool IsEventNotification => EntityType == EntityType.Event;
        public bool IsUserNotification => throw new NotImplementedException("User notification will be implemented in the future");
    }
}