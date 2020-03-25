using System;

namespace LCP.Refactoring.Courses
{
    public class TraineeNotEnrolledException : Exception
    {
        public TraineeNotEnrolledException(ITrainee trainee, ICourse course) : 
            base(($"Trainee [{trainee}] is not enrolled in course [{course}]"))
        {

        }
    }
}