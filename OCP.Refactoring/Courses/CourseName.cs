using System;

namespace OCP.Refactoring.Courses
{
	public class CourseName
	{
		public string Name { get; }

		private CourseName(string name)
		{
			ValidateName(name);

			Name = name;
		}

		public static CourseName Of(string name)
		{
			return new CourseName(name);
		}

		private static void ValidateName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Name is required", nameof(name));
			}
		}
	}
}