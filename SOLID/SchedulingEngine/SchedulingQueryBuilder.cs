using System.Collections.Generic;
using SOLID.SchedulingRequests;
using SOLID.SchedulingRules;

namespace SOLID.SchedulingEngine
{
	public class SchedulingQueryBuilder
	{
		public SchedulingQuery Build(
			SchedulingRequest request,
			List<SchedulingRule> rules,
			IList<Order> orders)
		{
			//some building logic here
			return new SchedulingQuery(request, rules, orders);
		}
	}
}