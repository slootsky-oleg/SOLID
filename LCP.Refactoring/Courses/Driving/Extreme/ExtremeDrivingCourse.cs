using System;
using System.Collections.Generic;
using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Driving.Extreme
{
    public class ExtremeDrivingCourse : ICourse
    {
        private readonly HashSet<ExtremeDrivingTrainee> trainees;
        private readonly Dictionary<ExtremeDrivingTrainee, WIll> traineeWills;
        private readonly DrivingCourseTraineeValidator traineeValidator;

        public CourseName Name { get; }


        public ExtremeDrivingCourse(CourseName name, AgeSpan ageSpan, VisualAcuity visualAcuity)
        {
            if (ageSpan == null) throw new ArgumentNullException(nameof(ageSpan));
            if (visualAcuity == null) throw new ArgumentNullException(nameof(visualAcuity));

            Name = name ?? throw new ArgumentNullException(nameof(name));

            this.traineeValidator = new DrivingCourseTraineeValidator(ageSpan, visualAcuity);
            this.trainees = new HashSet<ExtremeDrivingTrainee>();
            this.traineeWills = new Dictionary<ExtremeDrivingTrainee, WIll>();
        }

        public void Enroll(ExtremeDrivingTrainee trainee, WIll will)
        {
            traineeValidator.Validate(trainee);

            if (!trainees.Add(trainee))
            {
                throw new TraineeAlreadyEnrolledException(trainee, this);
            }
            
            traineeWills.Add(trainee, will);
        }

        public void Complete()
        {
            foreach (var trainee in trainees)
            {
                trainee.CompleteExtremeSkills();
            }
        }

        public WIll GetWIll(ExtremeDrivingTrainee trainee)
        {
            return traineeWills.TryGetValue(trainee, out var will) 
                ? will 
                : throw new TraineeNotEnrolledException(trainee,this);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}