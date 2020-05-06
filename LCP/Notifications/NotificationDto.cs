using System.Collections.Generic;

namespace LCP.Notifications
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public EntityType EntityType { get; set; }
        public TargetAudience TargetAudience { get; set; }
        public string TargetAudienceText { get; set; }
        public string AdditionalInfo { get; set; }
        public CourseType CourseType { get; set; }
        public Dictionary<int, string> AvailableTargetAudiences { get; set; }
        public EventOwner EventOwner { get; set; }
    }
}