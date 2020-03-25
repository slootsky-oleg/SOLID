using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Enroll(Trainee trainee, string will = null)
        {
            if (this is DrivingCourse drivingCourse && trainee is DrivingTrainee drivingTrainee)
            {
                if (drivingTrainee.Age < drivingCourse.MinAge || drivingTrainee.Age > drivingCourse.MaxAge)
                {
                    throw new InvalidOperationException($"Driver must be between the ages of {drivingCourse.MinAge} and {drivingCourse.MaxAge}.");
                }

                if (drivingTrainee.VisionPercent < 75)
                {
                    throw new InvalidOperationException($"Driver must have a good vision.");
                }

                if (this is ExtremeDrivingCourse extremeDriving)
                {
                    if (!drivingTrainee.Categories.Any())
                    {
                        throw new InvalidOperationException($"Driver must have driving license.");
                    }

                    extremeDriving.wills.Add(drivingTrainee, will);
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
                if (this is DrivingCourse drivingCourse && trainee is DrivingTrainee drivingTrainee)
                {
                    if (this is ExtremeDrivingCourse extremeDriving)
                    {
                        drivingTrainee.IsExtremeDriver = true;
                    }
                    else
                    {
                        foreach (var category in drivingCourse.Categories)
                        {
                            if (!drivingTrainee.Categories.Contains(category))
                            {
                                drivingTrainee.Categories.Add(category);
                            }
                        }
                    }
                }

                if (this is PracticeShootingCourse shootingLicensing && trainee is ShootingTrainee shootingTrainee)
                {
                    shootingTrainee.HasLicense = true;
                }
            }
        }

        public string GetWill(DrivingTrainee trainee)
        {
            if (this is ExtremeDrivingCourse extremeDrivingCourse)
            {
                return extremeDrivingCourse.wills[trainee];
            }

            throw new InvalidOperationException("Will is not supported");
        }
    }
}
