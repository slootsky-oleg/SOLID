using System;
using System.Collections.Generic;
using System.Linq;
using OCP.Refactoring.Subjects;

namespace OCP.Refactoring.Courses
{
	public class Course
	{
		public CourseName Name { get; }
		public double PassingGrade { get; }
		public IReadOnlyList<SubjectEvaluation> Evaluations { get; }

		public Course(CourseName name, double passingGrade, IEnumerable<SubjectEvaluation> evaluations)
		{
			var evaluationList = evaluations?.ToList()
			                     ?? throw new ArgumentNullException(nameof(evaluations));

			ValidatePassingGrade(evaluationList, passingGrade);

			this.Name = name ?? throw new ArgumentNullException(nameof(name));
			this.PassingGrade = passingGrade;
			this.Evaluations = evaluationList;
		}

		private static void ValidatePassingGrade(IList<SubjectEvaluation> evaluations, double grade)
		{
			var maxGrade = evaluations.Sum(e => e.Weight);
			if (grade > maxGrade)
			{
				var message = $"Passing grade [{grade}] must be less than [{maxGrade}].";
				throw new ArgumentOutOfRangeException(message);
			}
		}

		public double TotalGrade()
		{
			return Evaluations.Sum(e => e.Grade());
		}

		public bool IsPassed()
		{
			var allPassed = Evaluations.All(e => e.IsPassed());
			return allPassed
			       && PassingGrade >= TotalGrade();
		}
	}
}