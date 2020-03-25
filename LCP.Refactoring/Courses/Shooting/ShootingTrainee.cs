using System;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Shooting
{
    public class ShootingTrainee : ITrainee
    {
        public TraineeName Name { get; }
        public bool IsLicensed { get; private set; }
        public Age Age { get; }
        public bool IsFirearmsSafetyCourseCompleted { get; private set; }

        private ShootingTrainee(TraineeName name, Age age)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age ?? throw new ArgumentNullException(nameof(age));
        }

        public static ShootingTrainee Acknowledged(TraineeName name, Age age)
        {
            var trainee = new ShootingTrainee(name, age);
            trainee.CompleteFirearmsSafety();

            return trainee;
        }
        
        public static ShootingTrainee Newbie(TraineeName name, Age age)
        {
            return new ShootingTrainee(name, age);
        }

        public void CompleteFirearmsSafety()
        {
            IsFirearmsSafetyCourseCompleted = true;
        }

        public void CompleteLicense()
        {
            IsLicensed = true;
        }
    }
}