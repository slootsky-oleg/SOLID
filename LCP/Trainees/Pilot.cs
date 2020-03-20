using LCP.Scores;

namespace LCP.Trainees
{
    public class Pilot : Trainee
    {
        public Pilot(string name) : base(name)
        {
        }

        public new PilotScore Score { get; set; }
    }
}