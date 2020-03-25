using System;
using JetBrains.Annotations;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving
{
    public class DrivingCourseTraineeValidator
    {
        private readonly AgeSpan ageSpan;
        private readonly VisualAcuity visualAcuity;

        public DrivingCourseTraineeValidator(AgeSpan ageSpan, VisualAcuity visualAcuity)
        {
            this.ageSpan = ageSpan;
            this.visualAcuity = visualAcuity;
        }

        public void Validate(IDrivingTrainee trainee)
        {
            ageSpan.Validate(trainee.Age);
            ValidateVisualAcuity(trainee); 
        }

        [AssertionMethod]
        private void ValidateVisualAcuity(IDrivingTrainee trainee)
        {
            if (trainee.VisualAcuity < visualAcuity)
            {
                throw new InvalidOperationException($"Driver {trainee} must have at least [{visualAcuity}] visual acuity.");
            }
        }
    }
}