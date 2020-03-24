namespace LCP.Courses.Shooting
{
    public class ShootingTrainee : ITrainee
    {
        public bool HasLicense { get; set; }
        public int Age { get; set; }
        public bool IsFirearmsSafetyCourseCompleted { get; set; }
    }
}