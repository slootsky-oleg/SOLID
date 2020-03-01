using SRP.Refactoring.SchedulingEngine;

namespace SRP.Refactoring.SchedulingRequests
{
	public interface ISchedulingResponseRepository
	{
		void Save(SchedulingResponse schedulingResponse);
	}
}