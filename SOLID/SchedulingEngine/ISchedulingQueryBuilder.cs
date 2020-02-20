using System.Collections.Generic;
using SOLID.SchedulingRequests;
using SOLID.SchedulingRules;

namespace SOLID.SchedulingEngine
{
	public interface ISchedulingQueryBuilder
	{
		SchedulingQuery Build(SchedulingRequest schedulingRequest, List<SchedulingRule> requiredRules, IList<Order> requestOrders);
	}
}