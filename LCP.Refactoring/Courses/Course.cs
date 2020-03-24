﻿using System;
using System.Collections.Generic;
using LCP.Courses.Driving;
using LCP.Courses.Shooting;

namespace LCP.Courses
{
    public abstract class Course
    {
        private IList<Trainee> trainees;

        protected Course()
        {
            this.trainees = new List<Trainee>();
        }

        public void Enroll(Trainee trainee)
        {
            if (this is PracticeDrivingCourse drivingCourse && trainee is DrivingTrainee drivingTrainee)
            {
                if (drivingTrainee.Age < drivingCourse.MinAge || drivingTrainee.Age > drivingCourse.MaxAge)
                {
                    throw new InvalidOperationException($"Driver must be between the ages of {drivingCourse.MinAge} and {drivingCourse.MaxAge}.");
                }

                if (drivingTrainee.VisionPercent < 75)
                {
                    throw new InvalidOperationException($"Driver must have a good vision.");
                }
            }

            if (this is PracticeShootingCourse shootingCourse && trainee is ShootingTrainee shootingTrainee)
            {
                if (shootingTrainee.Age < shootingCourse.MinAge)
                {
                    throw new InvalidOperationException($"Shooter must be at least {shootingCourse.MinAge} years old.");
                }

                if (!shootingTrainee.IsFirearmsSafetyCourseCompleted)
                {
                    throw new InvalidOperationException($"Shooter must complete safety course before.");
                }
                
            }

            trainees.Add(trainee);
        }

        public void Complete()
        {
            foreach (var trainee in trainees)
            {
                if (this is PracticeDrivingCourse drivingLicensing && trainee is DrivingTrainee drivingTrainee)
                {

                    if (!drivingTrainee.Categories.Contains(drivingLicensing.Category))
                    {
                        drivingTrainee.Categories.Add(drivingLicensing.Category);
                    }
                }

                if (this is PracticeShootingCourse shootingLicensing && trainee is ShootingTrainee shootingTrainee)
                {
                    shootingTrainee.HasLicense = true;
                }
            }
        }
    }
}
