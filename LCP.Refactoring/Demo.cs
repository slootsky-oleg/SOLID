using LCP.Refactoring.Courses.Driving;
using LCP.Refactoring.Courses.Driving.Extreme;
using LCP.Refactoring.Courses.Shooting;

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
            var driver1 = new DrivingTrainee();
            var driver1Will = new WIll( "my will");

            var driver2 = new DrivingTrainee();
            var driver2Will = new WIll("my will");

            var extremeDriving = new ExtremeDrivingCourse(null);
            extremeDriving.Enroll(driver1, driver1Will);
            extremeDriving.Enroll(driver2, driver2Will);

            extremeDriving.Complete();
        }

        private static void RunShooting()
        {
            var shooter1 = new ShootingTrainee();
            var shooter2 = new ShootingTrainee();

            var shooting = new ShootingCourse();
            shooting.Enroll(shooter1);
            shooting.Enroll(shooter2);

            shooting.Complete();
        }

        private static void RunDriving()
        {
            var driver1 = new DrivingTrainee();
            var driver2 = new DrivingTrainee();

            var driving = new DrivingCourse();
            driving.Enroll(driver1);
            driving.Enroll(driver2);

            driving.Complete();
        }
    }
}