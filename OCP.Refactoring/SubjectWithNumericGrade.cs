using System;

namespace OCP.Refactoring
{
	public class SubjectWithNumericGrade : ISubject
	{
		private readonly GradeScale gradeScale;

		public string Name { get; }
		public double Grade { get; private set; }

		public SubjectWithNumericGrade(string name, GradeScale gradeScale)
		{
			this.Name = name;
			this.gradeScale = gradeScale;
			this.Grade = gradeScale.Min;
		}


		public double NormalizedGrade()
		{
			return Grade / gradeScale.Range;
		}

		public bool IsPassed()
		{
			return gradeScale.IsPassing(Grade);
		}

		public void Complete(double grade)
		{
			if (!gradeScale.IsValidGrade(grade))
			{
				throw new ArgumentOutOfRangeException(nameof(grade), grade, "Invalid grade");
			}

			Grade = grade;
		}
	}
}