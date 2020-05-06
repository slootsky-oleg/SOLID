namespace LCP.Refactoring.Domain.Entities.Notifications.Event
{
    public class EventTargetAudienceItem : TargetAudienceItem<EventTargetAudience>
    {
        public EventTargetAudienceItem(EventTargetAudience value) : base(value)
        {
        }

        public EventTargetAudienceItem(EventTargetAudience value, bool isChecked) : base(value, isChecked)
        {
        }
    }
}