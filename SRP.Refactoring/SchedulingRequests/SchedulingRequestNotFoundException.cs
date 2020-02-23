using System;

namespace SRP.Refactoring.SchedulingRequests
{
	public class SchedulingRequestNotFoundException : Exception
	{
		public SchedulingRequestNotFoundException(long requestId)
			: base($"Request [{requestId}] not found.")
		{
		}
	}
}