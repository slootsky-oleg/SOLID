using System;
using System.Collections.Generic;
using System.Linq;

namespace OCP.Refactoring
{
	public class Course
	{
		public string Name { get; }
		public double PassingGrade { get; }
		public IReadOnlyList<SubjectEvaluation> Evaluations { get; }

		public Course(string name, double passingGrade, IEnumerable<SubjectEvaluation> evaluations)
		{
			var evaluationList = evaluations?.ToList()
			                     ?? throw new ArgumentNullException(nameof(evaluations));

			this.Name = name;
			this.PassingGrade = passingGrade;
			this.Evaluations = evaluationList;
		}

		public double TotalGrade()
		{
			return Evaluations.Sum(e => e.Grade());
		}

		public bool IsPassed()
		{
			var allPassed = Evaluations.All(e => e.IsPassed());
			return allPassed
			       && TotalGrade() >= PassingGrade;
		}
	}
}