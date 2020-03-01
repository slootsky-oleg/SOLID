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
						var binaryGrade = subject.BinaryGrade;
						grade += binaryGrade ? subject.Weight : 0;
						break;
					case GradeType.Numeric:
						var numericGrade = subject.NumericGrade;
						var normalizedGrade = numericGrade / (subject.HighestGrade - subject.LowestGrade);
						grade += normalizedGrade * subject.Weight;
						break;
					default:
						//TODO: throw specific exception, keep grade type
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

						//TODO: isOptional -> isMandatory()
						if (!isPassed && !subject.IsOptional)
							return false;
						break;
					case GradeType.Numeric:
						var numericGrade = subject.NumericGrade;
						if (numericGrade < subject.PassingGrade && !subject.IsOptional)
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