using LCP.Courses.Driving;
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
            var driver1 = new DrivingTrainee() { Name = "driver 1" };
            var driver1Will = "my will";

            var driver2 = new DrivingTrainee() { Name = "driver 2" };
            var driver2Will = "my will";

            var extremeDriving = new ExtremeDrivingCourse();
            extremeDriving.Enroll(driver1, driver1Will);
            extremeDriving.Enroll(driver2, driver2Will);

            extremeDriving.Complete();
        }

        private static void RunShooting()
        {
            var shooter1 = new ShootingTrainee() { Name = "shooter 1" };
            var shooter2 = new ShootingTrainee() { Name = "shooter 2" };

            var shooting = new PracticeShootingCourse();
            shooting.Enroll(shooter1);
            shooting.Enroll(shooter2);

            shooting.Complete();
        }

        private static void RunDriving()
        {
            var driver1 = new DrivingTrainee() { Name = "driver 1" };
            var driver2 = new DrivingTrainee() { Name = "driver 2" };

            var driving = new DrivingCourse();
            driving.Enroll(driver1);
            driving.Enroll(driver2);

            driving.Complete();
        }
    }
}