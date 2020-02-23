using System.Collections.Generic;
using SOLID.SchedulingRequests;
using SOLID.SchedulingRules;

namespace SOLID.SchedulingEngine
{
	public class SchedulingQueryBuilder
	{
		public SchedulingQuery Build(
			SchedulingRequest schedulingRequest,
			List<SchedulingRule> requiredRules,
			IList<Order> requestOrders)
		{
			//some building logic here
			return new SchedulingQuery(schedulingRequest, requiredRules, requestOrders);
		}
	}
}