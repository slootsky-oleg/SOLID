using System;
using LCP.Courses.Shooting;

namespace LCP.Courses.Driving
{
    public class ExtremeDrivingCourse
    {
        private readonly PracticeDrivingCourse drivingCourse;

        public string TraineeWillSignature { get; private set; }

        public ExtremeDrivingCourse()
        {
            drivingCourse = new PracticeDrivingCourse
            {
                MinAge = 27,
                MaxAge = 60
            };
        }

        public void SignWill(ExtremeDrivingTrainee trainee)
        {
            TraineeWillSignature = trainee.Signature;
        }

        public void Enroll(ExtremeDrivingTrainee trainee)
        {
            SignWill(trainee);

            drivingCourse.Enroll(trainee.Trainee);
        }

        public void Complete(ExtremeDrivingTrainee trainee)
        {
            var drivingTrainee = trainee.Trainee;

            foreach (var category in drivingCourse.Categories)
            {
                if (!drivingTrainee.Categories.Contains(category))
                {
                    drivingTrainee.Categories.Add(category);
                }
            }
    }

    public class ExtremeSyllabus
    {
        public PracticeShootingCourse ShootingCourse { get; set; }
        public ExtremeDrivingCourse ExtremeDriving { get; set; }

        public void Enroll(PracticeShootingCourse course)
        {
            ShootingCourse = course;
        }

        public void Enroll(ExtremeDrivingCourse course)
        {
            ExtremeDriving = course;
            //TODO: signature for each trainee
            Console.WriteLine($"Trainee signature: {course.TraineeWillSignature}");
        }
    }
}