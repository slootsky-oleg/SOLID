namespace SOLID.SchedulingEngine
{
	public interface ISchedulingEngine
	{
		SchedulingResponse Schedule(SchedulingQuery schedulingQuery);
	}
}