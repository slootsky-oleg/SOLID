using System;

namespace OCP.Refactoring
{
	public class SubjectWithBinaryGrade : ISubject
	{
		public string Name { get; }
		public bool Grade { get; private set; }

		public SubjectWithBinaryGrade(string name)
		{
			this.Name = name;
		}

		public double NormalizedGrade()
		{
			return Convert.ToDouble(Grade);
		}

		public bool IsPassed()
		{
			return Grade;
		}

		public void Complete(bool grade)
		{
			Grade = grade;
		}
	}
}