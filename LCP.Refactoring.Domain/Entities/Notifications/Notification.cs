using System;
using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public class Notification<TAudience> where TAudience : struct, IConvertible
    {
        public Id Id { get; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        private readonly IList<TargetAudienceItem<TAudience>> targetAudiences;

        public IReadOnlyList<TargetAudienceItem<TAudience>> TargetAudiences => targetAudiences.ToList();


        public Notification(string name)
            : this(name, true, new List<TargetAudienceItem<TAudience>>())
        {
        }

        public Notification(Id id, string name)
            : this(id, name, true, new List<TargetAudienceItem<TAudience>>())
        {
        }

        public Notification(Id id, string name, bool isActive, IEnumerable<TargetAudienceItem<TAudience>> targetAudienceItems)
            : this(name, isActive, targetAudienceItems)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public Notification(string name, bool isActive, IEnumerable<TargetAudienceItem<TAudience>> targetAudienceItems)
        {
            Name = name;
            IsActive = isActive;
            this.targetAudiences = targetAudienceItems?.ToList() 
                                   ?? throw new ArgumentNullException(nameof(targetAudienceItems));
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void CheckTargetAudience(TAudience audience)
        {
            var item = GetTargetAudience(audience);
            item.Check();
        }

        public void UncheckTargetAudience(TAudience audience)
        {
            var item = GetTargetAudience(audience);
            item.Uncheck();
        }

        private TargetAudienceItem<TAudience> GetTargetAudience(TAudience audience)
        {
            return targetAudiences.Single(a => a.Value.Equals(audience));
        }
    }
}