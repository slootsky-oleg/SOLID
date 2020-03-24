using System;
using System.Collections.Generic;
using LCP.Courses.Shooting;

namespace LCP.Courses.Driving.Extreme
{
    public class ExtremeDrivingCourse
    {
        private readonly PracticeDrivingCourse drivingCourse;
        private Dictionary<DrivingTrainee, string> traineeWills;


        public ExtremeDrivingCourse()
        {
            drivingCourse = new PracticeDrivingCourse
            {
                MinAge = 27,
                MaxAge = 60
            };

            traineeWills = new Dictionary<DrivingTrainee, string>();

        }


        public void Enroll(DrivingTrainee trainee, string will)
        {
            traineeWills.Add(trainee, will);
            drivingCourse.Enroll(trainee);
        }

        public void Complete()
        {
            drivingCourse.Complete();
        }
    }
}