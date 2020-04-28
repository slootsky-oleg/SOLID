using System;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public class TargetAudienceItem <T> : IEquatable<T> where T: struct, IConvertible
    {
        public T Value { get; }
        public bool IsChecked { get; private set; }

        public TargetAudienceItem(T value)
        {
            Value = value;
        }

        public TargetAudienceItem(T value, bool isChecked)
            : this(value)
        {
            IsChecked = isChecked;
        }

        internal void Check()
        {
            IsChecked = true;
        }
        internal void Uncheck()
        {
            IsChecked = false;
        }

        protected bool Equals(TargetAudienceItem<T> other)
        {
            return Value.Equals(other.Value);
        }

        public bool Equals(T other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TargetAudienceItem<T>) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(TargetAudienceItem<T> left, TargetAudienceItem<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TargetAudienceItem<T> left, TargetAudienceItem<T> right)
        {
            return !Equals(left, right);
        }
    }
}