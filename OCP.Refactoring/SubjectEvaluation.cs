using OCP.Refactoring.Subjects;

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
			this.Subject = subject;
		}

		public static SubjectEvaluation Mandatory(ISubject subject, double weight)
		{
			return new SubjectEvaluation(subject, weight, false);
		}

		public static SubjectEvaluation Optional(ISubject subject, double weight)
		{
			return new SubjectEvaluation(subject, weight, true);
		}

		public double Grade()
		{
			return Subject.Grade() * Weight;
		}

		public bool IsPassed()
		{
			return IsOptional || Subject.IsPassed();
		}
	}
}