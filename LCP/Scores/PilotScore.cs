namespace LCP.Scores
{
    public class PilotScore : Score
    {
        public override double Value { get; }
        public double Factor { get; set; }

        public PilotScore(double value, double factor)
        {
            Value = value;
            Factor = factor;
        }
    }
}