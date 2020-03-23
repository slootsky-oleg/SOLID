using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace LCP
{
    public abstract class Course
    {
        private IList<Trainee> trainees;

        protected Course()
        {
            this.trainees = new List<Trainee>();
        }

        //TODO: validate licenses in the middle of the course

        public void Enroll(Trainee trainee)
        {
            if (this is DrivingLicensingCourse drivingLicensing && trainee is DrivingTrainee drivingTrainee)
            {
                if (drivingTrainee.VisionPercent < 75)
                {
                    throw new InvalidOperationException($"Trainee must have a good vision.");
                }
            }

            trainees.Add(trainee);
        }

        public void Complete()
        {
            foreach (var trainee in trainees)
            {
                if (this is DrivingLicensingCourse drivingLicensing && trainee is DrivingTrainee drivingTrainee)
                {
                    if (drivingTrainee.Age <= drivingLicensing.MinAge || drivingTrainee.Age >= drivingLicensing.MaxAge)
                    {
                        throw new InvalidOperationException($"Trainee's age must be above {drivingLicensing.MinAge} and less {drivingLicensing.MaxAge} years old.");
                    }

                    if (!drivingTrainee.Categories.Contains(drivingLicensing.Category))
                    {
                        drivingTrainee.Categories.Add(drivingLicensing.Category);
                    }
                }

                if (this is ShootingLicensingCourse shootingLicensing && trainee is ShootingTrainee shootingTrainee)
                {
                    shootingTrainee.HasLicense = true;
                }
            }
        }
    }

    public class ShootingTrainee : Trainee
    {
        public bool HasLicense { get; set; }
    }

    public class ShootingLicensingCourse : Course
    {
    }

    public abstract class Trainee
    {
    }

    public class DrivingTrainee : Trainee
    {
        public int Age { get; set; }
        public int VisionPercent { get; set; }
        public IList<char> Categories { get; set; }
    }
}
