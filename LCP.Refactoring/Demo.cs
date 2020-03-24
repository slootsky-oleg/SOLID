using LCP.Courses.Driving;
using LCP.Courses.Driving.Extreme;
using LCP.Courses.Shooting;

namespace LCP
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
            var driver1Will = "my will";

            var driver2 = new DrivingTrainee();
            var driver2Will = "my will";

            var extremeDriving = new ExtremeDrivingCourse();
            extremeDriving.Enroll(driver1, driver1Will);
            extremeDriving.Enroll(driver2, driver2Will);

            extremeDriving.Complete();
        }

        private static void RunShooting()
        {
            var shooter1 = new ShootingTrainee();
            var shooter2 = new ShootingTrainee();

            var shooting = new PracticeShootingCourse();
            shooting.Enroll(shooter1);
            shooting.Enroll(shooter2);

            shooting.Complete();
        }

        private static void RunDriving()
        {
            var driver1 = new DrivingTrainee();
            var driver2 = new DrivingTrainee();

            var driving = new PracticeDrivingCourse();
            driving.Enroll(driver1);
            driving.Enroll(driver2);

            driving.Complete();
        }
    }
}