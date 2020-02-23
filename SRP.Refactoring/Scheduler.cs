using SRP.Refactoring.SchedulingEngine;
using SRP.Refactoring.SchedulingRequests;
using SRP.Refactoring.SchedulingRules;

namespace SRP.Refactoring
{
	public class Scheduler
	{
		private readonly SchedulingQueryBuilder queryBuilder;
		private readonly SchedulingExecutor schedulingExecutor;
		private readonly SchedulingRequestStore requestStore;
		private readonly SchedulingRulesStore rulesStore;
		private readonly SchedulingResponseSaver responseSaver;

		public Scheduler(SchedulingRequestStore requestStore,
			SchedulingRulesStore rulesStore,
			SchedulingQueryBuilder queryBuilder,
			SchedulingExecutor schedulingExecutor,
			SchedulingResponseSaver responseSaver)
		{
			this.requestStore = requestStore;
			this.queryBuilder = queryBuilder;
			this.schedulingExecutor = schedulingExecutor;
			this.rulesStore = rulesStore;
			this.responseSaver = responseSaver;
		}

		public void Schedule(long requestId)
		{
			var request = requestStore.GetById(requestId);
			var requiredRules = rulesStore.Get(request);

			var query = queryBuilder.Build(request, requiredRules);

			var response = schedulingExecutor.Schedule(query);
			responseSaver.SaveResponse(response);
		}
	}
}
