using System;
using System.Collections.Generic;
using LCP.Courses.Driving;
using LCP.Courses.Shooting;

namespace LCP.Courses
{
    public abstract class Course<T> where T: ITrainee
    {
        //readonly
        private readonly IList<T> trainees;

        protected Course()
        {
            this.trainees = new List<T>();
        }

        protected abstract void ValidateTrainee(T trainee);

        public void Enroll(T trainee)
        {
            ValidateTrainee(trainee);

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
