namespace LCP.Refactoring.Domain.Entities.Notifications.Course
{
    public class CourseTargetAudienceItem : TargetAudienceItem<CourseTargetAudience>
    {
        public CourseTargetAudienceItem(CourseTargetAudience value) : base(value)
        {
        }

        public CourseTargetAudienceItem(CourseTargetAudience value, bool isChecked) : base(value, isChecked)
        {
        }

        internal void Check()
        {
            IsChecked = true;
        }
        internal void Uncheck()
        {
            IsChecked = false;
        }
    }
}