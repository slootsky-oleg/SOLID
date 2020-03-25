using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses
{
    public class TraineeName : Name
    {
        private TraineeName(string value) 
            : base(value)
        {
        }

        public static TraineeName From(string name)
        {
            return new TraineeName(name);
        }
    }
}