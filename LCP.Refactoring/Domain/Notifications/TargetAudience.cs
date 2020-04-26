namespace LCP.Refactoring.Domain.Notifications
{
    public class TargetAudience <T>
    {
        public T Value { get; }
        public bool IsSelected { get; private set; }
    }
}