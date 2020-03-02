using System.Collections.Generic;

namespace OCP
{
	public class Demo
	{
		public void Execute()
		{
			var adding = new Subject("Adding", false, 0.9, 0, 100, 60, GradeType.Numeric);
			var subtracting = new Subject("Subtracting", false, 1, 0, 0, 0, GradeType.Binary);
			var multiplying = new Subject("Multiplying", false, 1.5, 0, 10, 5, GradeType.Numeric);
			var dividing = new Subject("Dividing", false, 1.5, 0, 100, 60, GradeType.Numeric);
			var fractions = new Subject("Fractions", true, 1.8, 0, 0, 0, GradeType.Binary);

			var mathSubjects = new List<Subject>
			{
				adding,
				subtracting,
				multiplying,
				fractions,
				dividing
			};
			var mathCourse = new Course("Math", mathSubjects);

			adding.Grade(80);
			subtracting.Grade(true);
			multiplying.Grade(6);
			dividing.Grade(70);
			fractions.Grade(false);

			var mathGrade = mathCourse.CalculateGrade();
			var isPassed = mathCourse.IsPassed()
			               && mathGrade > 5.5;
		}
	}
}