using System.Collections.Generic;

namespace LCP.Refactoring.Courses.Driving.Extreme
{
    public class ExtremeDrivingCourse
    {
        private readonly PracticeDrivingCourse drivingCourse;
        private readonly Dictionary<DrivingTrainee, WIll> traineeWills;


        public ExtremeDrivingCourse()
        {
            drivingCourse = new PracticeDrivingCourse
            {
                MinAge = 27,
                MaxAge = 60
            };

            traineeWills = new Dictionary<DrivingTrainee, WIll>();
        }


        public void Enroll(DrivingTrainee trainee, WIll will)
        {
            traineeWills.Add(trainee, will);
            drivingCourse.Enroll(trainee);
        }

        public void Complete()
        {
            drivingCourse.Complete();
        }

        public WIll GetWIll(DrivingTrainee trainee)
        {
            return traineeWills[trainee];
        }
    }
}