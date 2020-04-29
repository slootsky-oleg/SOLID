using System;

namespace LCP.Refactoring.Domain.Values
{
    public class Id
    {
        private readonly long value;

        private Id(long value)
        {
            if (value < 0)
                throw new ArgumentException($"Invalid value {value}");

            this.value = value;
        }

        public static Id From(long value)
        {
            return new Id(value);
        }

        protected bool Equals(Id other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Id) obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Id left, Id right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Id left, Id right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}