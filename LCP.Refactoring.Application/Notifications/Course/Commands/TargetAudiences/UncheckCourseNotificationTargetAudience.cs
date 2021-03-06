﻿using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Entities.Notifications.Course;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Course.Commands.TargetAudiences
{
    public class UncheckCourseNotificationTargetAudience
    {
        private readonly ICourseNotificationRepository repository;

        public UncheckCourseNotificationTargetAudience(ICourseNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id, CourseTargetAudience audience)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.UncheckTargetAudience(audience);

            repository.Save(notification);
        }
    }
}