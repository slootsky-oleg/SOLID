using System;

namespace SOLID.Optimizations
{
	public class OptimizationNotFoundException : Exception
	{
		public OptimizationNotFoundException(long requestId)
			: base($"Request {requestId} not found.")
		{
		}
	}
}