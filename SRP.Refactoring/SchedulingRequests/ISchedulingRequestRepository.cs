namespace SRP.Refactoring.SchedulingRequests
{
	public interface ISchedulingRequestRepository
	{
		SchedulingRequest GetById(long id);
	}
}