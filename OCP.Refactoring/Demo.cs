using System.Collections.Generic;
using OCP.Refactoring.Subjects.BinaryGrade;
using OCP.Refactoring.Subjects.NumericGrade;

namespace OCP.Refactoring
{
	public class Demo
	{
		public void Execute()
		{
			var gradeScale100Passed60 = new NamericScale(100, 60);
			var gradeScale10Passed5 = new NamericScale(10, 5);

			var adding = new SubjectWithNumericGrade("Adding", gradeScale100Passed60);
			var subtracting = new SubjectWithBinaryGrade("Subtracting");
			var multiplying = new SubjectWithNumericGrade("Multiplying", gradeScale10Passed5);
			var fractions = new SubjectWithBinaryGrade("Fractions");
			var dividing = new SubjectWithNumericGrade("Dividing", gradeScale100Passed60);

			var mathSubjects = new List<SubjectEvaluation>
			{
				SubjectEvaluation.Mandatory(adding, 0.9),
				SubjectEvaluation.Mandatory(subtracting, 1),
				SubjectEvaluation.Mandatory(multiplying, 1.5),
				SubjectEvaluation.Mandatory(dividing, 1.5),
				SubjectEvaluation.Optional(fractions, 1.8),
			};
			var mathCourse = new Course("Math", 5.5, mathSubjects);

			adding.Complete(80);
			subtracting.Complete(true);
			multiplying.Complete(6);
			dividing.Complete(70);
			fractions.Complete(false);

			var mathGrade = mathCourse.TotalGrade();
			var isPassed = mathCourse.IsPassed();
		}
	}
}