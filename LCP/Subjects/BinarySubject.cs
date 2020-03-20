namespace LCP.Subjects
{
    public class BinarySubject : Subject
    {
        public void SetGrade(bool newGrade)
        {
            IsPassed = newGrade;
        }

        //TODO: is used?
        public bool IsPassed { get; private set; }
    }
}