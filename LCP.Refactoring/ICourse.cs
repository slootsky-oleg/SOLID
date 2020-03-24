using LCP.Courses;

namespace LCP
{
    public interface ICourse
    {
        void Enroll(ITrainee trainee);
        void Complete();
    }
}