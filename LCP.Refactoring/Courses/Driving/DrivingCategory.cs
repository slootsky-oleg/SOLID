using System;
using System.Collections.Generic;

namespace LCP.Refactoring.Courses.Driving
{
    public class DrivingCategory
    {
        private static readonly List<string> Known = new List<string> { "A", "A1", "B", "C", "C1", "E", "D", "D1", "D1"};

        private readonly string value;

        private DrivingCategory(string value)
        {
            Validate(value);

            this.value = value;
        }

        public static DrivingCategory From(string value)
        {
            return new DrivingCategory(value);
        }

        protected bool Equals(DrivingCategory other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrivingCategory) obj);
        }

        public override int GetHashCode()
        {
            return (value != null ? value.GetHashCode() : 0);
        }

        public static bool operator ==(DrivingCategory left, DrivingCategory right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DrivingCategory left, DrivingCategory right)
        {
            return !Equals(left, right);
        }

        private static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Category is required.");
            }

            if (!Known.Contains(value))
            {
                throw new ArgumentException($"Invalid category [{value}].");
            }
        }
    }
}