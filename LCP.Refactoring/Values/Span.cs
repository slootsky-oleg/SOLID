using System;

namespace LCP.Refactoring.Values
{
    public class Span<T> where T: class, IComparable<T>
    {
        public T Start { get; }
        public T End { get; }

        public Span(T start, T end)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            End = end ?? throw new ArgumentNullException(nameof(end));

            if (start.CompareTo(end) > 0)
            {
                throw new ArgumentException($"Start [{start}] must precede [{end}].");
            }
        }
    }
}