using System;
using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving
{
    public class DrivingTrainee : ITrainee
    {
        private readonly HashSet<DrivingCategory> categories;

        public Age Age { get; }
        public VisualAcuity VisualAcuity { get; }

        public IReadOnlyList<DrivingCategory> Categories => categories.ToList();

        public DrivingTrainee(Age age, VisualAcuity visualAcuity)
        {
            Age = age ?? throw new ArgumentNullException(nameof(age));
            VisualAcuity = visualAcuity ?? throw new ArgumentNullException(nameof(visualAcuity));

            this.categories = new HashSet<DrivingCategory>();
        }

        public DrivingTrainee(Age age, VisualAcuity visualAcuity, IEnumerable<DrivingCategory> categories) 
            : this(age, visualAcuity)
        {
            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }

            this.categories.UnionWith(categories);
        }

        public void CompleteCategory(DrivingCategory category)
        {
            categories.Add(category);
        }
    }
}