namespace OCP.Refactoring
{
	public class SubjectEvaluation
	{
		public double Weight { get; }
		public bool IsOptional { get; }
		public ISubject Subject { get; }

		private SubjectEvaluation(ISubject subject, double weight, bool isOptional)
		{
			this.Weight = weight;
			this.IsOptional = isOptional;
			Subject = subject;
		}

		public static SubjectEvaluation Mandatory(ISubject subject, double weight)
		{
			return new SubjectEvaluation(subject, weight, false);
		}

		public static SubjectEvaluation Optional(ISubject subject, double weight)
		{
			return new SubjectEvaluation(subject, weight, true);
		}

		public double GetGrade()
		{
			return Subject.NormalizedGrade() * Weight;
		}

		public bool IsPassed()
		{
			return IsOptional || Subject.IsPassed();
		}
	}
}