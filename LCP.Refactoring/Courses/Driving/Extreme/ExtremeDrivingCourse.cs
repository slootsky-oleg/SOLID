using System;
using System.Collections.Generic;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving.Extreme
{
    public class ExtremeDrivingCourse : ICourse
    {
        private readonly DrivingCourse drivingCourse;
        private readonly Dictionary<DrivingTrainee, WIll> traineeWills;

        public CourseName Name => drivingCourse.Name;


        public ExtremeDrivingCourse(CourseName name,
            AgeSpan ageSpan,
            VisualAcuity visualAcuity,
            IEnumerable<DrivingCategory> categories) 
        {
            traineeWills = new Dictionary<DrivingTrainee, WIll>();
            drivingCourse = new DrivingCourse(name, ageSpan, visualAcuity, categories);
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
            return traineeWills.TryGetValue(trainee, out var will) 
                ? will 
                : throw new InvalidOperationException($"Trainee [{trainee}] is not enrolled in course [{this}]");
        }

        public override string ToString()
        {
            return drivingCourse.ToString();
        }
    }
}