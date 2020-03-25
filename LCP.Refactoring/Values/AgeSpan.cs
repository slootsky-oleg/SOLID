using System;

namespace LCP.Refactoring.Values
{
    public class AgeSpan : Span<Age>
    {
        public AgeSpan(Age start, Age end) : base(start, end)
        {
        }

        public void Validate(Age age)
        {
            if (age == null) throw new ArgumentNullException(nameof(age));

            if (age < Start || age > End)
            {
                throw new InvalidOperationException($"Age must be between {Start} and {End}.");
            }
        }
    }
}