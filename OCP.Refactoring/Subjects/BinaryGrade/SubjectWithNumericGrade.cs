using System;
using OCP.Refactoring.Subjects.NumericGrade;

namespace OCP.Refactoring.Subjects.BinaryGrade
{
	public class SubjectWithNumericGrade : ISubject
	{
		private readonly GradeScale scale;
		private double grade;

		public string Name { get; }

		public SubjectWithNumericGrade(string name, GradeScale scale)
		{
			this.Name = name;
			this.scale = scale;
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