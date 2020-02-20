namespace SOLID.SchedulingEngine
{
	internal interface ISchedulingEngine
	{
		SchedulingResponse Schedule(SchedulingRequest schedulingRequest);
	}
}