using System;

namespace LCP.Refactoring.Values
{
    public class VisualAcuity : IComparable<VisualAcuity>
    {
        private int value;

        private VisualAcuity(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Visual acuity [{value}] must be positive.");
            }

            this.value = value;
        }

        public static VisualAcuity From(int value)
        {
            return new VisualAcuity(value);
        }

        public int CompareTo(VisualAcuity other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return value.CompareTo(other.value);
        }

        protected bool Equals(VisualAcuity other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((VisualAcuity) obj);
        }

        public override int GetHashCode()
        {
            return value;
        }

        public static bool operator ==(VisualAcuity left, VisualAcuity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(VisualAcuity left, VisualAcuity right)
        {
            return !Equals(left, right);
        }

        public static bool operator >(VisualAcuity left, VisualAcuity right)
        {
            if (Equals(left, right))
            {
                return false;
            }

            return left.value > right.value;
        }

        public static bool operator <(VisualAcuity left, VisualAcuity right)
        {
            if (Equals(left, right))
            {
                return false;
            }

            return left.value < right.value;
        }
    }
}