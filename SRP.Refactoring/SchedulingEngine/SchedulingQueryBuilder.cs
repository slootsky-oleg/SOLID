using System.Collections.Generic;
using SRP.Refactoring.SchedulingRequests;
using SRP.Refactoring.SchedulingRules;

namespace SRP.Refactoring.SchedulingEngine
{
	public class SchedulingQueryBuilder
	{
		public SchedulingQuery Build(
			SchedulingRequest schedulingRequest,
			List<SchedulingRule> requiredRules,
			IList<Order> requestOrders)
		{
			//some building logic
			//TODO: pass all with constructor
			var query = new SchedulingQuery(schedulingRequest, requiredRules, requestOrders);
			query.Start = schedulingRequest.Start;
			query.End = schedulingRequest.End;

			return query;
		}
	}
}