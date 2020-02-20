using System;

namespace SOLID.SchedulingRequests
{
	public class SchedulingRequestNotFoundException : Exception
	{
		public SchedulingRequestNotFoundException(long requestId)
			: base($"Request [{requestId}] not found.")
		{
		}
	}
}