using System;
using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving
{
    internal class DrivingCourse : Course<DrivingTrainee>
    {
        private readonly AgeSpan ageSpan;
        private readonly VisualAcuity visualAcuity;
        private readonly IList<DrivingCategory> categories;

        public DrivingCourse(AgeSpan ageSpan, VisualAcuity visualAcuity, IEnumerable<DrivingCategory> categories)
        {
            this.ageSpan = ageSpan ?? throw new ArgumentNullException(nameof(ageSpan));
            this.visualAcuity = visualAcuity ?? throw new ArgumentNullException(nameof(visualAcuity));
            this.categories = categories?.ToList() ?? throw new ArgumentNullException(nameof(categories));
        }


        protected override void ValidateTrainee(DrivingTrainee trainee)
        {
            ageSpan.Validate(trainee.Age);

            ValidateVisualAcuity(trainee.VisualAcuity);
        }

        private void ValidateVisualAcuity(VisualAcuity validatingAcuity)
        {
            if (validatingAcuity < visualAcuity)
            {
                throw new InvalidOperationException($"Driver must have at least [{visualAcuity}] visual acuity.");
            }
        }

        protected override void CompleteCourse(DrivingTrainee trainee)
        {
            foreach (var category in categories)
            {
                trainee.CompleteCategory(category);
            }
        }
    }
}