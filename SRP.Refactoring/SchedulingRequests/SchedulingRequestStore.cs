using System;
using System.Linq;

namespace SRP.Refactoring.SchedulingRequests
{
	public class SchedulingRequestStore
	{
		private readonly ISchedulingRequestRepository requestRepository;

		public SchedulingRequestStore(ISchedulingRequestRepository requestRepository)
		{
			this.requestRepository = requestRepository;
		}

		public SchedulingRequest GetById(long requestId)
		{
			var request = requestRepository.GetById(requestId)
			              ?? throw new SchedulingRequestNotFoundException(requestId);

			if (request.Orders?.Any() != true)
			{
				throw new InvalidSchedulingRequestException(requestId, "Request must contain orders.");
			}

			if (request.End >= DateTime.Now)
			{
				throw new InvalidSchedulingRequestException(requestId, "Optimization must be active.");
			}

			return request;
		}
	}
}