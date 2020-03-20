using LCP.Scores;

namespace LCP.Trainees
{
    public class Trainee
    {
        public string Name { get; }

        public Trainee(string name)
        {
            Name = name;
        }

        public Score Score => null;
    }
}