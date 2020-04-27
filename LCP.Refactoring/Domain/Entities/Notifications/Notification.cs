using System;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public class Notification
    {
        public Id Id { get; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Notification(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }

        public Notification(Id id, string name, bool isActive)
            : this(name, isActive)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}