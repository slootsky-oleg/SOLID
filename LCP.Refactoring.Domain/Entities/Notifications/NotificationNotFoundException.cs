using System;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public class NotificationNotFoundException : Exception
    {
        public Id Id { get; }

        public NotificationNotFoundException(Id id)
            : base($"Notification with Id [{id}] not found.")
        {
            Id = id;
        }
    }
}