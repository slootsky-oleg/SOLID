using System;
using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Domain.Values;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public class Notification<T> where T : struct, IConvertible
    {
        public Id Id { get; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        private readonly IList<TargetAudienceItem<T>> targetAudiences;

        public IReadOnlyList<TargetAudienceItem<T>> TargetAudiences => targetAudiences.ToList();


        public Notification(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
            this.targetAudiences = new List<TargetAudienceItem<T>>();
        }

        public Notification(string name, bool isActive, IEnumerable<TargetAudienceItem<T>> targetAudienceItems)
        {
            Name = name;
            IsActive = isActive;
            this.targetAudiences = targetAudienceItems?.ToList() 
                                   ?? throw new ArgumentNullException(nameof(targetAudienceItems));
        }

        public Notification(Id id, string name, bool isActive, IEnumerable<TargetAudienceItem<T>> targetAudienceItems)
            : this(name, isActive, targetAudienceItems)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void CheckTargetAudience(T audience)
        {
            var item = GetTargetAudience(audience);
            item.Check();
        }

        public void UncheckTargetAudience(T audience)
        {
            var item = GetTargetAudience(audience);
            item.Uncheck();
        }

        private TargetAudienceItem<T> GetTargetAudience(T audience)
        {
            return targetAudiences.Single(a => a.Value.Equals(audience));
        }
    }
}