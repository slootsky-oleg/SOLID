using System;
using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving
{
    public class DrivingTrainee : IDrivingTrainee
    {
        private readonly HashSet<DrivingCategory> categories;

        public TraineeName Name { get; }
        public Age Age { get; }
        public VisualAcuity VisualAcuity { get; }

        public IReadOnlyList<DrivingCategory> Categories => categories.ToList();


        public DrivingTrainee(TraineeName name, Age age, VisualAcuity visualAcuity)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age ?? throw new ArgumentNullException(nameof(age));
            VisualAcuity = visualAcuity ?? throw new ArgumentNullException(nameof(visualAcuity));

            this.categories = new HashSet<DrivingCategory>();
        }

        public DrivingTrainee(TraineeName name, Age age, VisualAcuity visualAcuity, IEnumerable<DrivingCategory> categories) 
            : this(name, age, visualAcuity)
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

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}