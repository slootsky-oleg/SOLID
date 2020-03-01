using System;

namespace OCP
{
	public class Subject
	{
		public bool BinaryGrade { get; private set; }
		public double NumericGrade { get; private set; }
		public string Name { get; }
		public bool IsOptional { get; }
		public double Weight { get; }
		public double LowestGrade { get; }
		public double HighestGrade { get; }
		public double PassingGrade { get; }
		public GradeType GradeType { get; }


		public Subject(string name, bool isOptional, double weight, double lowestGrade, double highestGrade, double passingGrade, GradeType gradeType)
		{
			this.Name = name;
			this.LowestGrade = lowestGrade;
			this.HighestGrade = highestGrade;
			this.PassingGrade = passingGrade;
			this.GradeType = gradeType;
			this.IsOptional = isOptional;
			this.Weight = weight;
		}

		public void Grade(bool grade)
		{
			this.BinaryGrade = grade;
		}

		public void Grade(double grade)
		{
			this.NumericGrade = grade;
		}
	}
}