using System;
using JetBrains.Annotations;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Shooting
{
    public class ShootingCourse : Course<ShootingTrainee>
    {
        private Age MinAge { get; }

        public ShootingCourse(CourseName name, Age minAge) : base(name)
        {
            MinAge = minAge;
        }

        protected override void ValidateTrainee(ShootingTrainee trainee)
        {
            ValidateAge(trainee.Age);

            ValidateSafetySkills(trainee);
        }

        [AssertionMethod]
        private void ValidateAge(Age age)
        {
            if (age < MinAge)
            {
                throw new InvalidOperationException($"Shooter must be at least {MinAge} years old.");
            }
        }

        [AssertionMethod]
        private static void ValidateSafetySkills(ShootingTrainee trainee)
        {
            if (!trainee.IsFirearmsSafetyCourseCompleted)
            {
                throw new InvalidOperationException($"Shooter must complete safety course before.");
            }
        }

        protected override void CompleteCourse(ShootingTrainee trainee)
        {
            trainee.CompleteLicense();
        }
    }
}