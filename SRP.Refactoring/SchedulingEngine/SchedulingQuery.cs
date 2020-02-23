using System;
using System.Collections.Generic;
using SRP.Refactoring.SchedulingRequests;
using SRP.Refactoring.SchedulingRules;

namespace SRP.Refactoring.SchedulingEngine
{
	public class SchedulingQuery
	{
		public SchedulingRequest SchedulingRequest { get; }
		public IList<SchedulingRule> RequiredRules { get; }
		public IList<Order> RequestOrders { get; }

		public SchedulingQuery(SchedulingRequest schedulingRequest, IList<SchedulingRule> requiredRules, IList<Order> requestOrders)
		{
			SchedulingRequest = schedulingRequest;
			RequiredRules = requiredRules;
			RequestOrders = requestOrders;
		}

		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}