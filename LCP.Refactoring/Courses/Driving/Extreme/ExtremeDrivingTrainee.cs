using System;
using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving.Extreme
{
    public class ExtremeDrivingTrainee : IDrivingTrainee
    {
        private readonly DrivingTrainee baseTrainee;

        public TraineeName Name => baseTrainee.Name;
        public Age Age => baseTrainee.Age;
        public VisualAcuity VisualAcuity => baseTrainee.VisualAcuity;
        public bool IsExtremeDriver { private set; get; }


        public ExtremeDrivingTrainee(TraineeName name, Age age, VisualAcuity visualAcuity, IEnumerable<DrivingCategory> categories)
        {
            if (categories?.Any() != true)
            {
                throw new InvalidOperationException($"Driver [{name}] must have driving license.");
            }

            baseTrainee = new DrivingTrainee(name,age, visualAcuity, categories);
        }

        public void CompleteExtremeSkills()
        {
            IsExtremeDriver = true;
        }

        public override string ToString()
        {
            return baseTrainee.ToString();
        }
    }
}