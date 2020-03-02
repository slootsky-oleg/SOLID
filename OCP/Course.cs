using System;
using System.Collections.Generic;

namespace OCP
{
	public class Course
	{
		public string Name { get; }
		public IList<Subject> Subjects { get; }

		public Course(string name, IList<Subject> subjects)
		{
			this.Name = name;
			this.Subjects = subjects;
		}

		public double CalculateGrade()
		{
			double grade = 0;

			foreach (var subject in Subjects)
			{
				switch (subject.GradeType)
				{
					case GradeType.Binary:
						var binaryGrade = Convert.ToDouble(subject.BinaryGrade);
						grade += binaryGrade * subject.Weight;
						break;
					case GradeType.Numeric:
						var normalizedGrade = subject.NumericGrade / (subject.HighestGrade - subject.LowestGrade);
						grade += normalizedGrade * subject.Weight;
						break;
					default:
						throw new Exception("Not supported grade type");
				}
			}

			return grade;
		}

		public bool IsPassed()
		{
			foreach (var subject in Subjects)
			{
				switch (subject.GradeType)
				{
					case GradeType.Binary:
						var isPassed = subject.BinaryGrade;

						if (!isPassed && !subject.IsOptional)
							return false;
						break;
					case GradeType.Numeric:
						var numericPassed = subject.NumericGrade >= subject.PassingGrade;
						if (!numericPassed && !subject.IsOptional)
							return false;
						break;
					default:
						throw new Exception("un supported grade type");
				}
			}

			return true;
		}
	}
}