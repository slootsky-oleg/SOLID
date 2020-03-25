using System.Collections.Generic;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving.Extreme
{
    public class ExtremeDrivingCourse
    {
        private readonly DrivingCourse drivingCourse;
        private readonly Dictionary<DrivingTrainee, WIll> traineeWills;


        public ExtremeDrivingCourse(AgeSpan ageSpan, VisualAcuity visualAcuity, IEnumerable<DrivingCategory> categories)
        {
            traineeWills = new Dictionary<DrivingTrainee, WIll>();
            drivingCourse = new DrivingCourse(ageSpan, visualAcuity, categories);
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