﻿using LCP.Refactoring.Domain.Entities.Notifications;
using LCP.Refactoring.Domain.Repositories;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Application.Notifications.Event.Commands.Activate
{
    //It might me tempting to use the same activator/deactivator for all notification types.
    //Yet consider requirement: allow activation from specific date only for the Course notification.
    public class ActivateEventNotification
    {
        private readonly IEventNotificationRepository repository;

        public ActivateEventNotification(IEventNotificationRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(Id id)
        {
            var notification = repository.Get(id) 
                               ?? throw new NotificationNotFoundException(id);

            notification.Activate();

            repository.Save(notification);
        }
    }
}