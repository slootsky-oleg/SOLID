using System;

namespace LCP.Refactoring.Values
{
    public abstract class AbstractName
    {
        private readonly string value;

        protected AbstractName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name is required.");
            }

            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }

        protected bool Equals(AbstractName other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AbstractName) obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(AbstractName left, AbstractName right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AbstractName left, AbstractName right)
        {
            return !Equals(left, right);
        }
    }
}