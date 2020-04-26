namespace LCP.Refactoring.Domain.Notifications
{
    public class Notification
    {
        public long Id { get; }
        public string Name { get; }
        public bool IsActive { get; }

        public Notification(long id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
    }
}