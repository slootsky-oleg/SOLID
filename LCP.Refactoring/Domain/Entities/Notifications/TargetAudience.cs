using System;
using System.Collections.Generic;

namespace LCP.Refactoring.Domain.Entities.Notifications
{
    public class TargetAudience <T> where T: struct, IConvertible
    {
        public T Value { get; protected set; }
        public bool IsChecked { get; protected set; }

        public TargetAudience(T value)
        {
            Value = value;
        }

        public TargetAudience(T value, bool isChecked)
            : this(value)
        {
            IsChecked = isChecked;
        }

        public void Check()
        {
            IsChecked = true;
        }
        public void Uncheck()
        {
            IsChecked = false;
        }

        protected bool Equals(TargetAudience<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TargetAudience<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(TargetAudience<T> left, TargetAudience<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TargetAudience<T> left, TargetAudience<T> right)
        {
            return !Equals(left, right);
        }
    }
}