using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LCP.Refactoring.Courses
{
    public abstract class Course<T> : ICourse  
        where T: ITrainee
    {
        private readonly HashSet<T> trainees;
        public CourseName Name { get; }


        protected Course(CourseName name)
        {
            this.trainees = new HashSet<T>();

            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        protected abstract void ValidateTrainee(T trainee);
        protected abstract void CompleteCourse(T trainee);


        public void Enroll(T trainee)
        {
            ValidateTrainee(trainee);

            if (!trainees.Add(trainee))
            {
                throw new TraineeAlreadyEnrolledException(trainee, this);
            }
        }

        // void ICourse.Enroll(ITrainee trainee)
        //
        // {
        //     Enroll((T) trainee);
        // }


        public void Complete()
        {
            foreach (var trainee in trainees)
            {
                CompleteCourse(trainee);
            }
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
