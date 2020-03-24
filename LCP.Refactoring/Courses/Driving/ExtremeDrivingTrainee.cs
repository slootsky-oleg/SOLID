using System.Collections.Generic;

namespace LCP.Courses.Driving
{
    public class ExtremeDrivingTrainee
    {
        public DrivingTrainee Trainee { get; }



        public string Signature { get; set; }

        public ExtremeDrivingTrainee()
        {
            this.Trainee = new DrivingTrainee();
        }
    }
}