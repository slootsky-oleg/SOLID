using System;

namespace OCP.Refactoring.Subjects.BinaryGrade
{
	public class BinaryGradeSubject : ISubject
	{
		public SubjectName Name { get; }
		private bool grade;

		public BinaryGradeSubject(SubjectName name)
		{
			this.Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public double Grade()
		{
			return Convert.ToDouble(grade);
		}

		public bool IsPassed()
		{
			return grade;
		}

		public void Complete(bool completeGrade)
		{
			grade = completeGrade;
		}
	}
}