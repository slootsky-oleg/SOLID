namespace SRP.Refactoring.SchedulingEngine
{
	public interface ISchedulingEngine
	{
		SchedulingResponse Schedule(SchedulingQuery schedulingQuery);
	}
}