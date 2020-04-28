using LCP.Refactoring.Domain.Services;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications.Resource
{
    public class ResourceNotification
    {
        private readonly Notification<int> baseNotification;

        public Id Id => baseNotification.Id;

        public string Name
        {
            get => baseNotification.Name;
            set => baseNotification.Name = value;
        }

        public ResourceNotification(string name)
        {
            this.baseNotification = new Notification<int>(name);
        }

        public ResourceNotification(Id id, string name)
            : this(name)
        {
            this.baseNotification = new Notification<int>(id, name);
        }
    }
}