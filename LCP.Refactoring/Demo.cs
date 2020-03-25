using System.Collections.Generic;
using LCP.Refactoring.Courses;
using LCP.Refactoring.Courses.Driving;
using LCP.Refactoring.Courses.Driving.Extreme;
using LCP.Refactoring.Courses.Shooting;
using LCP.Refactoring.Values;

namespace LCP.Refactoring
{
    public class Demo
    {
        public void Run()
        {
            RunShooting();

            RunDriving();

            RunExtremeDriving();
        }

        private static void RunExtremeDriving()
        {
            var driver1 = new ExtremeDrivingTrainee(
                TraineeName.From("Jon"),
                Age.From(32),
                VisualAcuity.From(90),
                new []{DrivingCategory.From("A")});
            var driver1Will = WIll.From( "my will");

            var driver2 = new ExtremeDrivingTrainee(
                TraineeName.From("Daniel"),
                Age.From(64),
                VisualAcuity.From(52),
                new[] {DrivingCategory.From("A")});
            var driver2Will = WIll.From("my will");

            var ageSpan = new AgeSpan(Age.From(29), Age.From(65));
            var extremeDriving = new ExtremeDrivingCourse(
                CourseName.From("Very dangerous"),
                ageSpan,
                VisualAcuity.From(50));

            extremeDriving.Enroll(driver1, driver1Will);
            extremeDriving.Enroll(driver2, driver2Will);

            extremeDriving.Complete();
        }

        private static void RunShooting()
        {
            var shooter1 = ShootingTrainee.Newbie(TraineeName.From("Jon"), Age.From(25));
            var shooter2 = ShootingTrainee.Acknowledged(TraineeName.From("Mike"), Age.From(43));

            var shooting = new ShootingCourse(CourseName.From("Firearms"), Age.From(22));
            shooting.Enroll(shooter1);
            shooting.Enroll(shooter2);

            shooting.Complete();
        }

        private static void RunDriving()
        {
            var driver1 = new DrivingTrainee(TraineeName.From("Jon"), Age.From(32), VisualAcuity.From(90));
            var driver2 = new DrivingTrainee(TraineeName.From("Daniel"), Age.From(64), VisualAcuity.From(52));

            var ageSpan = new AgeSpan(Age.From(29), Age.From(65));
            var categories = new List<DrivingCategory>
            {
                DrivingCategory.From("A")
            };

            var driving = new DrivingCourse(
                CourseName.From("Very dangerous"),
                ageSpan,
                VisualAcuity.From(50),
                categories);
            driving.Enroll(driver1);
            driving.Enroll(driver2);

            driving.Complete();
        }
    }
}