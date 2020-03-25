using System;

namespace LCP.Refactoring.Values
{
    public class Age : IComparable<Age>
    {
        private int value;

        public Age(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Age [{value}] must be positive.");
            }

            this.value = value;
        }

        public int CompareTo(Age other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return value.CompareTo(other.value);
        }

        protected bool Equals(Age other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Age) obj);
        }

        public override int GetHashCode()
        {
            return value;
        }

        public static bool operator ==(Age left, Age right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Age left, Age right)
        {
            return !Equals(left, right);
        }

        public static bool operator >(Age left, Age right)
        {
            if (Equals(left, right))
            {
                return false;
            }

            return left.value > right.value;
        }

        public static bool operator <(Age left, Age right)
        {
            if (Equals(left, right))
            {
                return false;
            }

            return left.value < right.value;
        }
    }
}