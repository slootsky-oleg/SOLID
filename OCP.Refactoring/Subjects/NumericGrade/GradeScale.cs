using System;

namespace OCP.Refactoring.Subjects.NumericGrade
{
	public class GradeScale
	{
		public double Min { get; }
		public double Max { get; }
		public double Passing { get; }

		public double Range => Max - Min;

		public GradeScale(double min, double max, double passing)
		{
			ValidateRange(min, max);
			Min = min;
			Max = max;

			ValidatePassingGrade(passing);
			Passing = passing;
		}

		public GradeScale(double max, double passing)
			: this(0, max, passing)
		{
		}

		private static void ValidateRange(double min, double max)
		{
			if (min > max)
			{
				throw new ArgumentException($"Invalid grade range: [{min}] - [{max}].");
			}
		}

		private void ValidatePassingGrade(double passing)
		{
			if (!IsValidGrade(passing))
			{
				throw new ArgumentException($"Passing grade [{passing}] must in: [{Min}] - [{Max}].");
			}
		}

		public bool IsPassing(double grade)
		{
			return grade >= Passing;
		}

		public bool IsValidGrade(double grade)
		{
			return grade >= Min
			       && grade <= Max;
		}
	}
}