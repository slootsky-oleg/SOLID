using System.Collections.Generic;
using System.Security.AccessControl;

namespace LCP.Courses.Driving
{
    internal class ExtremeDrivingCourse : DrivingCourse
    {
        public IDictionary<DrivingTrainee, string> wills { get; set; }

        public ExtremeDrivingCourse()
        {
            wills = new Dictionary<DrivingTrainee, string>();
        }
    }
}