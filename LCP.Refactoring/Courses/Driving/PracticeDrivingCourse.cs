using System;
using System.Collections.Generic;

namespace LCP.Courses.Driving
{
    internal class PracticeDrivingCourse : Course<DrivingTrainee>
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public IEnumerable<char> Categories { get; set; }

        protected override void ValidateTrainee(DrivingTrainee trainee)
        {
            if (trainee.Age < MinAge || trainee.Age > MaxAge)
            {
                throw new InvalidOperationException($"Driver must be between the ages of {MinAge} and {MaxAge}.");
            }

            if (trainee.VisionPercent < 75)
            {
                throw new InvalidOperationException($"Driver must have a good vision.");
            }
        }

        protected override void CompleteCourse(DrivingTrainee trainee)
        {
            foreach (var category in Categories)
            {
                if (!trainee.Categories.Contains(category))
                {
                    trainee.Categories.Add(category);
                }
            }
        }
    }
}