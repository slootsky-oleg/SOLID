using System;

namespace LCP.Refactoring.Courses.Driving.Extreme
{
    public class WIll
    {
        private readonly string text;

        public WIll(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Will is required.");
            }

            this.text = text;
        }

        public override string ToString()
        {
            return text;
        }

        private bool Equals(WIll other)
        {
            return text == other.text;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WIll) obj);
        }

        public override int GetHashCode()
        {
            return text.GetHashCode();
        }

        public static bool operator ==(WIll left, WIll right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WIll left, WIll right)
        {
            return !Equals(left, right);
        }
    }
}