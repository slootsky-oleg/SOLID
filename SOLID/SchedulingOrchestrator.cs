using System;
using System.Linq;
using SOLID.SchedulingEngine;
using SOLID.SchedulingRequests;
using SOLID.SchedulingRules;

namespace SOLID
{
	public class SchedulingOrchestrator
	{
		private readonly ISchedulingRequestRepository schedulingRequestRepository;
		private readonly ISchedulingRulesRepository schedulingRulesRepository;
		private readonly SchedulingQueryBuilder queryBuilder;
		private readonly ISchedulingEngine schedulingEngine;

		public SchedulingOrchestrator(ISchedulingRequestRepository schedulingRequestRepository,
			ISchedulingRulesRepository schedulingRulesRepository,
			SchedulingQueryBuilder queryBuilder,
			ISchedulingEngine schedulingEngine)
		{
			this.schedulingRequestRepository = schedulingRequestRepository;
			this.schedulingRulesRepository = schedulingRulesRepository;
			this.queryBuilder = queryBuilder;
			this.schedulingEngine = schedulingEngine;
		}

		public void Schedule(long requestId)
		{
			var request = schedulingRequestRepository.GetById(requestId)
			              ?? throw new SchedulingRequestNotFoundException(requestId);

			if (request.Orders?.Any() != true)
			{
				throw new InvalidSchedulingRequestException(requestId, "Request must contain orders.");
			}

			if (request.End >= DateTime.Now)
			{
				throw new InvalidSchedulingRequestException(requestId, "Optimization must be active.");
			}

			var rules = schedulingRulesRepository.GetAll();
			var requiredRules = rules
				.Where(r => r.Department == request.Department)
				.ToList();

			var query = queryBuilder.Build(request, requiredRules, request.Orders);
			query.Start = request.Start;
			query.End = request.End;

			try
			{
				var response = schedulingEngine.Schedule(query);
				schedulingRequestRepository.Save(response);
			}
			catch (Exception e)
			{
				//try one more time
				try
				{
					var response = schedulingEngine.Schedule(query);
					schedulingRequestRepository.Save(response);
				}
				catch (Exception exception)
				{
				}
			}
		}
	}
}
