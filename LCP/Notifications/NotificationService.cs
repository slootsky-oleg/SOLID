﻿using System;
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
                else if (source.IsResourceNotification)
                {
                    var resourceNotification = (ResourceNotification) source;
                    dto.AdditionalInfo = TextProvider.Get("Notification_ResourceType_" + resourceNotification.ResourceType);
                }

                foreach (TargetAudience value in Enum.GetValues(source.TargetAudience.GetType()))
                {
                    if (source.TargetAudience.HasFlag(value))
                    {
                        if (source.IsCourseNotification && ((CourseNotification) source).CourseType == CourseType.Scheduling && value == TargetAudience.User)
                        {
                            dto.TargetAudience += TextProvider.Get("Notification_TargetAudience_Participant");
                        }
                        else
                        {
                            dto.TargetAudience += TextProvider.Get("Notification_TargetAudience_" + value);
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
            dto.Active = source.Active;
            dto.EntityType = source.EntityType;

            if (source.IsCourseNotification)
            {
                var courseNotification = (CourseNotification) source;
                dto.CourseType = courseNotification.CourseType;
            }
            else if (source.IsResourceNotification)
            {
                var resourceNotification = (ResourceNotification) source;
                dto.ResourceType = resourceNotification.ResourceType;
            }

            var audienceTypes = new Dictionary<int, string>();
            if (source.IsCourseNotification && ((CourseNotification) source).CourseType == CourseType.Scheduling)
            {
                audienceTypes.Add((int)TargetAudience.User, TextProvider.Get("Notification_TargetAudience_Participant"));
            }

            if (source.IsCourseNotification && ((CourseNotification)source).CourseType != CourseType.Scheduling)
            {
                audienceTypes.Add((int)TargetAudience.User, TextProvider.Get("Notification_TargetAudience_" + (int)TargetAudience.User));
                audienceTypes.Add((int)TargetAudience.Manager, TextProvider.Get("Notification_TargetAudience_" + (int)TargetAudience.Manager));
            }

            if (source.IsResourceNotification && ((ResourceNotification)source).ResourceType == ResourceType.Human)
            {
                audienceTypes.Add((int)TargetAudience.User, TextProvider.Get("Notification_TargetAudience_Participant"));
            }

            dto.AvailableTargetAudiences = audienceTypes;

            return dto;
        }

        public long Save(NotificationDto dto)
        {
            //fill common fields
            //validate entity type
            //validate audiences
        }
    }
}