using System;

namespace OCP.Refactoring.Subjects
{
	public class SubjectName
	{
		public string Name { get; }

		private SubjectName(string name)
		{
			ValidateName(name);

			Name = name;
		}

		public static SubjectName Of(string name)
		{
			return new SubjectName(name);
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