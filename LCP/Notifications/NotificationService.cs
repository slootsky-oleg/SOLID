using System.Collections.Generic;
using System.Net.Http.Headers;
using LCP.Application;

namespace LCP.Notifications
{
    public class NotificationService
    {
        private readonly NotificationRepository notificationRepository;
        private readonly TextProvider textProvider;

        public NotificationService()
        {
            this.notificationRepository = new NotificationRepository();
        }

        public IList<NotificationDto> GetAll()
        {
            var notifications = notificationRepository.GetAll();

            foreach (var source in notifications)
            {
                var dto = new NotificationDto();
                dto.Id = source.Id;
                dto.Name = source.Name;
                dto.Active = source.Active;
                dto.EntityType = source.EntityType;
                dto.TargetAudience = source.TargetAudience;

                if (source.IsCourseNotification)
                {
                    var courseNotification = (CourseNotification) source;
                    dto.AdditionalInfo = TextProvider.Get("Notification_CourseType_" + courseNotification.CourseType);
                }
                else if (source.IsResourceNotification)
                {
                    var resourceNotification = (ResourceNotification)source;
                    dto.AdditionalInfo = TextProvider.Get("Notification_ResourceType_" + resourceNotification.ResourceType);
                }
            }
        }
    }

    //TODO: inherit specific dto for each notification. Their goal - create Additional info and target audience descriptions
    public class NotificationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public EntityType EntityType { get; set; }
        public TargetAudience TargetAudience { get; set; }

        public string AdditionalInfo { get; set; }
    }
}