using System;

namespace SOLID.Optimizations
{
	public class InvalidOptimizationException : Exception
	{
		public InvalidOptimizationException(long requestId, string message)
			: base($"Request {requestId} {message}.")
		{
		}
	}
}