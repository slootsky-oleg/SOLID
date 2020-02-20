using SOLID.SchedulingEngine;

namespace SOLID.SchedulingRequests
{
	public interface ISchedulingRequestRepository
	{
		SchedulingRequest GetById(long id);
		void Save(SchedulingResponse schedulingResponse);
	}
}