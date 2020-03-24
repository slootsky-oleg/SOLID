using LCP.Refactoring.Courses;

namespace LCP.Refactoring
{
    public interface ICourse
    {
        void Enroll(ITrainee trainee);
        void Complete();
    }
}