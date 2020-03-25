using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses
{
    public class CourseName : AbstractName
    {
        private CourseName(string value) 
            : base(value)
        {
        }

        public static CourseName From(string value)
        {
            return new CourseName(value);
        }
    }
}