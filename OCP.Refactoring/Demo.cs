using System.Collections.Generic;
using OCP.Refactoring;

namespace OCP
{
	public class Demo
	{
		public void Execute()
		{
			var gradeScale100Passed60 = new GradeScale(0, 100, 60);
			var gradeScale10Passed5 = new GradeScale(0, 10, 5);

			var adding = new SubjectWithNumericGrade("Adding", gradeScale100Passed60);
			adding.Complete(80);

			var subtracting = new SubjectWithBinaryGrade("Subtracting");
			subtracting.Complete(true);

			var multiplying = new SubjectWithNumericGrade("Multiplying", gradeScale10Passed5);
			multiplying.Complete(6);

			var fractions = new SubjectWithBinaryGrade("Fractions");
			fractions.Complete(false);

			var dividing = new SubjectWithNumericGrade("Dividing", gradeScale100Passed60);
			dividing.Complete(70);

			var mathSubjects = new List<SubjectEvaluation>
			{
				SubjectEvaluation.Mandatory(adding, 0.3),
				SubjectEvaluation.Mandatory(subtracting, 0.2),
				SubjectEvaluation.Mandatory(multiplying, 0.2),
				SubjectEvaluation.Optional(fractions, 0.1),
				SubjectEvaluation.Mandatory(dividing, 0.1),
			};

			var mathCourse = new Course("Math", 10, mathSubjects);
			var mathGrade = mathCourse.TotalGrade();
			var isPassed = mathCourse.IsPassed();
		}
	}
}