using System;

namespace OCP.Refactoring.Subjects.BinaryGrade
{
	public class SubjectWithBinaryGrade : ISubject
	{
		public string Name { get; }
		private bool grade;

		public SubjectWithBinaryGrade(string name)
		{
			this.Name = name;
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