using System.Collections.Generic;

namespace LCP.Courses.Driving
{
    public class DrivingTrainee : Trainee
    {
        public int Age { get; set; }
        public int VisionPercent { get; set; }
        public IList<string> Categories { get; set; }
        public bool IsExtremeDriver { get; set; }
    }
}