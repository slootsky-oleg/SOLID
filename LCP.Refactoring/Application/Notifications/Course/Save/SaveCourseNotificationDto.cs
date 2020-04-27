using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Notifications;
using LCP.Refactoring.Domain.Notifications.Course;
using LCP.Refactoring.Domain.Services;

namespace LCP.Refactoring.Application.Notifications.Course.Save
{
    public class SaveCourseNotificationDto
    {
        public long Id { get; }
        public string Name { get; }
    }
}