﻿using System;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public class NotificationNotFoundException : Exception
    {
        public long Id { get; }

        public NotificationNotFoundException(long id)
            : base($"Notification with Id [{id}] not found.")
        {
            Id = id;
        }
    }
}