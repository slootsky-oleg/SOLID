using System;

namespace OCP.Refactoring.Subjects
{
	public class SubjectName
	{
		public string Name { get; }

		public SubjectName(string name)
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