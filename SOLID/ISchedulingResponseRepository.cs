using SOLID.SchedulingEngine;

namespace SOLID
{
	internal interface ISchedulingResponseRepository
	{
		void Save(SchedulingResponse schedulingResponse);
	}
}