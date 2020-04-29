using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using LCP.Application;

namespace LCP.Notifications
{
    public class NotificationService
    {
        private readonly NotificationRepository notificationRepository;

        public NotificationService()
        {
            this.notificationRepository = new NotificationRepository();
        }

        public IList<NotificationDto> GetAll()
        {
            var notifications = notificationRepository.GetAll();

            var result = new List<NotificationDto>();
            foreach (var source in notifications)
            {
                var dto = new NotificationDto();
                dto.Id = source.Id;
                dto.Name = source.Name;
                dto.Active = source.Active;
                dto.EntityType = source.EntityType;

                if (source.IsCourseNotification)
                {
                    var courseNotification = (CourseNotification) source;
                    dto.AdditionalInfo = TextProvider.Get("Notification_CourseType_" + courseNotification.CourseType);
                }
                else if (source.IsEventNotification)
                {
                    var eventNotification = (EventNotification) source;
                    dto.AdditionalInfo = TextProvider.Get("Notification_EventOwner_" + eventNotification.EventOwner);
                }

                foreach (TargetAudience value in Enum.GetValues(source.TargetAudience.GetType()))
                {
                    if (source.TargetAudience.HasFlag(value))
                    {
                        if (source.IsCourseNotification && ((CourseNotification) source).CourseType == CourseType.Corporate && value == TargetAudience.User)
                        {
                            dto.TargetAudienceText += TextProvider.Get("Notification_TargetAudience_Participant");
                        }
                        else
                        {
                            dto.TargetAudienceText += TextProvider.Get("Notification_TargetAudience_" + value);
                        }
                    }
                }

                result.Add(dto);
            }

            return result;
        }

        public NotificationDto Get(int id)
        {
            var source = notificationRepository.Get(id);

            var dto = new NotificationDto();
            dto.Id = source.Id;
            dto.Name = source.Name;
            dto.EntityType = source.EntityType;

            if (source.IsCourseNotification)
            {
                var courseNotification = (CourseNotification) source;
                dto.CourseType = courseNotification.CourseType;
                dto.Active = source.Active;
                dto.TargetAudience = source.TargetAudience;
            }
            else if (source.IsResourceNotification)
            {
                //var resourceNotification = (ResourceNotification) source;
            }

            var audienceTypes = new Dictionary<int, string>();
            if (source.IsCourseNotification && ((CourseNotification) source).CourseType == CourseType.Corporate)
            {
                audienceTypes.Add((int)TargetAudience.User, TextProvider.Get("Notification_TargetAudience_Participant"));
            }

            if (source.IsCourseNotification && ((CourseNotification)source).CourseType != CourseType.Corporate)
            {
                audienceTypes.Add((int)TargetAudience.User, TextProvider.Get("Notification_TargetAudience_" + (int)TargetAudience.User));
                audienceTypes.Add((int)TargetAudience.Manager, TextProvider.Get("Notification_TargetAudience_" + (int)TargetAudience.Manager));
            }

            if (source.IsEventNotification)
            {
                audienceTypes.Add((int)TargetAudience.User, TextProvider.Get("Notification_TargetAudience_Participant"));
                audienceTypes.Add((int)TargetAudience.Manager, TextProvider.Get("Notification_TargetAudience_" + (int)TargetAudience.Manager));
                audienceTypes.Add((int)TargetAudience.SeniorManager, TextProvider.Get("Notification_TargetAudience_" + (int)TargetAudience.SeniorManager));

            }

            dto.AvailableTargetAudiences = audienceTypes;

            return dto;
        }

        public long SaveOrCreate(NotificationDto dto)
        {
            Notification notification;
            switch (dto.EntityType)
            {
                case EntityType.Course:
                    notification = new CourseNotification();
                    break;
                case EntityType.Resource:
                    notification = new ResourceNotification();
                    break;
                case EntityType.Event:
                    throw new NotImplementedException("Event notification will be implemented in the future");
                default:
                    throw new InvalidOperationException($"Unknown notification type [{dto.EntityType}]");
            }

            notification.Id = dto.Id;
            notification.Name = dto.Name;

            if (dto.Id < 1)
            {
                notification.EntityType = dto.EntityType;
            }

            if (notification.IsCourseNotification)
            {
                notification.Active = dto.Active;
                notification.TargetAudience = dto.TargetAudience;
                //Course type is not changeable

                //Audience Manager cannot be used with Scheduling course
                var courseNotification = (CourseNotification) notification;
                if (courseNotification.CourseType == CourseType.Corporate && (notification.TargetAudience & TargetAudience.Manager) > 0)
                {
                    throw new InvalidOperationException("Invalid target audience");
                }
            }

            if (notification.IsEventNotification)
            {
                notification.Active = dto.Active;
                notification.TargetAudience = dto.TargetAudience;

                var eventNotification = (EventNotification) notification;
                eventNotification.EventOwner = dto.EventOwner;
            }

            if (notification.IsUserNotification)
            {
                //will be implemented in next releases
            }

            //possible security break here.
            //possible entity type bug here for existing entity
            notificationRepository.Save(notification);

            return notification.Id;
        }
    }
}