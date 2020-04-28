using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications.Event
{
    public class EventNotification : Notification<EventTargetAudience>
    {
        private static readonly IList<EventTargetAudience> Audiences = GetAudiences();

        //TODO: update service to update owner
        public EventOwner EventOwner { get; set; }

        public EventNotification(string name, bool isActive, EventOwner eventOwner) 
            : base(name, isActive, BuildTargetAudiences())
        {
            EventOwner = eventOwner;
        }

        public EventNotification(Id id, string name, bool isActive, EventOwner eventOwner)
            : base(id, name, isActive, BuildTargetAudiences())
        {
            EventOwner = eventOwner;
        }

        private static IEnumerable<EventTargetAudienceItem> BuildTargetAudiences()
        {
            return Audiences.Select(a => new EventTargetAudienceItem(a));
        }

        private static IList<EventTargetAudience> GetAudiences() =>
            new List<EventTargetAudience>
            {
                EventTargetAudience.Participant,
                EventTargetAudience.Manager,
                EventTargetAudience.SeniorManager
            };
    }

    public enum EventOwner
    {
        Course,
        User
    }
}