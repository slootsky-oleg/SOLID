using System;

namespace OCP.Refactoring.Courses
{
	public class CourseName
	{
		public string Name { get; }

		public CourseName(string name)
		{
			ValidateName(name);

			Name = name;
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