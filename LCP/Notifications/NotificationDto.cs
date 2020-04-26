using System.Collections.Generic;

namespace LCP.Notifications
{
    //TODO: inherit specific dto for each notification. Their goal - create Additional info and target audience descriptions
    public class NotificationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public EntityType EntityType { get; set; }
        public TargetAudience TargetAudience { get; set; }
        public string TargetAudienceText { get; set; }
        public string TypeInfo { get; set; }
        public CourseType CourseType { get; set; }
        public ResourceType ResourceType { get; set; }
        public Dictionary<int, string> AvailableTargetAudiences { get; set; }
    }
}