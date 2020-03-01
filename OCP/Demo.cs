using System.Collections.Generic;

namespace OCP
{
	public class Demo
	{
		public void Execute()
		{
			var adding = new Subject("Adding", false, 0.3, 0, 100, 60, GradeType.Numeric);
			adding.Grade(80);

			var subtracting = new Subject("Subtracting", false, 0.2, 0, 1, 1, GradeType.Binary);
			subtracting.Grade(true);

			var multiplying = new Subject("Multiplying", false, 0.2, 0, 10, 5, GradeType.Numeric);
			multiplying.Grade(6);

			var fractions = new Subject("Fractions", true, 0.1, 0, 1, 1, GradeType.Binary);
			fractions.Grade(false);

			var dividing = new Subject("Dividing", false, 0.1, 0, 100, 60, GradeType.Numeric);
			dividing.Grade(70);

			var mathSubjects = new List<Subject>
			{
				adding,
				subtracting,
				multiplying,
				fractions,
				dividing
			};

			var mathCourse = new Course("Math", mathSubjects);
			var mathGrade = mathCourse.CalculateGrade();
			var isPassed = mathCourse.IsPassed();
		}
	}
}