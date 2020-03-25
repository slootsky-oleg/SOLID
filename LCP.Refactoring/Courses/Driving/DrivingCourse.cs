using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving
{
    internal class DrivingCourse : Course<DrivingTrainee>
    {
        private readonly AgeSpan ageSpan;
        private readonly VisualAcuity visualAcuity;
        private readonly IList<DrivingCategory> categories;
        private readonly DrivingCourseTraineeValidator traineeValidator;

        public DrivingCourse(CourseName name,
            AgeSpan ageSpan,
            VisualAcuity visualAcuity,
            IEnumerable<DrivingCategory> categories)
            : base(name)
        {
            this.ageSpan = ageSpan ?? throw new ArgumentNullException(nameof(ageSpan));
            this.visualAcuity = visualAcuity ?? throw new ArgumentNullException(nameof(visualAcuity));
            this.categories = categories?.ToList() ?? throw new ArgumentNullException(nameof(categories));

            this.traineeValidator = new DrivingCourseTraineeValidator(ageSpan, visualAcuity);
        }


        protected override void ValidateTrainee(DrivingTrainee trainee)
        {
            traineeValidator.Validate(trainee);
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