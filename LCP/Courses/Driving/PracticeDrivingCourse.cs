using System.Collections.Generic;

namespace LCP.Courses.Driving
{
    internal class PracticeDrivingCourse : Course
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public IList<char> Categories { get; set; }
    }
}