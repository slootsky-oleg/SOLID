using System;
using SRP.Refactoring.SchedulingEngine;
using SRP.Refactoring.SchedulingRules;

namespace SRP.Refactoring
{
	public class Scheduler
	{
		private readonly SchedulingQueryBuilder queryBuilder;
		private readonly ISchedulingEngine schedulingEngine;
		private readonly SchedulingRequestStore schedulingRequestStore;
		private readonly SchedulingRulesStore schedulingRulesStore;

		public Scheduler(SchedulingRequestStore requestStore,
			SchedulingRulesStore schedulingRulesStore,
			SchedulingQueryBuilder queryBuilder,
			ISchedulingEngine schedulingEngine)
		{
			schedulingRequestStore = requestStore;
			this.queryBuilder = queryBuilder;
			this.schedulingEngine = schedulingEngine;
			this.schedulingRulesStore = schedulingRulesStore;
		}

		public void Schedule(long requestId)
		{
			var request = schedulingRequestStore.GetById(requestId);
			var requiredRules = schedulingRulesStore.Get(request);
			var query = queryBuilder.Build(request, requiredRules, request.Orders);

			ScheduleAndSave(query);
		}

		private void ScheduleAndSave(SchedulingQuery query)
		{
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
