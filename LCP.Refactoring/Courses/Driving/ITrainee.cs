using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses
{
    public interface IDrivingTrainee : ITrainee
    {
        Age Age { get; }
        VisualAcuity VisualAcuity { get; }
    }
}