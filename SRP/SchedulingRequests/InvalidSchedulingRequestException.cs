using System;

namespace SOLID.SchedulingRequests
{
	public class InvalidSchedulingRequestException : Exception
	{
		public InvalidSchedulingRequestException(long requestId, string message)
			: base($"Invalid request [{requestId}]: {message}.")
		{
		}
	}
}