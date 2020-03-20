namespace LCP.Subjects
{
    public class BinarySubject : Subject
    {
        public BinarySubject(string name) : base(name)
        {
        }

        public void SetGrade(bool newGrade)
        {
            IsPassed = newGrade;
        }

        public bool IsPassed { get; private set; }
    }
}