using System;

namespace LCP.Refactoring.Courses
{
    public class TraineeAlreadyEnrolledException : Exception
    {
        public TraineeAlreadyEnrolledException(ITrainee trainee, ICourse course) : 
            base(($"Trainee [{trainee}] is already enrolled in the course [{course}]"))
        {

        }
    }
}