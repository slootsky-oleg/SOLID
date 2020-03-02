using System;

namespace OCP.Refactoring.Subjects.NumericGrade
{
	public class NumericGradeSubject : ISubject
	{
		private readonly NamericScale scale;
		private double grade;

		public SubjectName Name { get; }

		public NumericGradeSubject(SubjectName name, NamericScale scale)
		{
			this.Name = name ?? throw new ArgumentNullException(nameof(name));
			this.scale = scale ?? throw new ArgumentNullException(nameof(scale));
			this.grade = scale.Min;
		}

		public double Grade()
		{
			return grade / scale.Range;
		}

		public bool IsPassed()
		{
			return scale.IsPassing(grade);
		}

		public void Complete(double completeGrade)
		{
			if (!scale.IsValidGrade(completeGrade))
			{
				throw new ArgumentOutOfRangeException(nameof(completeGrade), completeGrade, "Invalid grade");
			}

			this.grade = completeGrade;
		}
	}
}