using System;

namespace LCP.Courses.Shooting
{
    public class PracticeShootingCourse : Course<ShootingTrainee>
    {
        public int MinAge { get; set; }

        protected override void ValidateTrainee(ShootingTrainee trainee)
        {
            if (trainee.Age < MinAge)
            {
                throw new InvalidOperationException($"Shooter must be at least {MinAge} years old.");
            }

            if (!trainee.IsFirearmsSafetyCourseCompleted)
            {
                throw new InvalidOperationException($"Shooter must complete safety course before.");
            }
        }

        protected override void CompleteCourse(ShootingTrainee trainee)
        {
            trainee.HasLicense = true;
        }
    }
}