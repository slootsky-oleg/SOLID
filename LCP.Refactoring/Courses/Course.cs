using System.Collections.Generic;

namespace LCP.Refactoring.Courses
{
    public abstract class Course<T> : ICourse  
        where T: ITrainee
    {
        //readonly
        private readonly IList<T> trainees;

        protected Course()
        {
            this.trainees = new List<T>();
        }

        protected abstract void ValidateTrainee(T trainee);
        protected abstract void CompleteCourse(T trainee);


        public void Enroll(T trainee)
        {
            ValidateTrainee(trainee);

            trainees.Add(trainee);
        }

        void ICourse.Enroll(ITrainee trainee)

        {
            Enroll((T) trainee);
        }


        public void Complete()
        {
            foreach (var trainee in trainees)
            {
                CompleteCourse(trainee);
            }
        }
    }
}
