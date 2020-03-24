using System.Collections.Generic;

namespace LCP.Courses.Driving
{
    public class DrivingTrainee : Trainee
    {
        public int Age { get; set; }
        public int VisionPercent { get; set; }
        public IList<char> Categories { get; set; }
    }
}