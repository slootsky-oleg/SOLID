using System;
using System.Collections.Generic;
using SRP.Refactoring.SchedulingRequests;
using SRP.Refactoring.SchedulingRules;

namespace SRP.Refactoring.SchedulingEngine
{
	public class SchedulingQuery
	{
		public SchedulingRequest Request { get; }
		public IList<SchedulingRule> Rules { get; }
		public IList<Order> Orders { get; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }

		public SchedulingQuery(SchedulingRequest request, IList<SchedulingRule> rules)
		{
			Request = request;
			Rules = rules;
			Orders = request.Orders;
		}
	}
}