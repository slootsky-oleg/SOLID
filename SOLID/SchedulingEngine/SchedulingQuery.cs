using System;
using System.Collections.Generic;
using SOLID.SchedulingRequests;
using SOLID.SchedulingRules;

namespace SOLID.SchedulingEngine
{
	public class SchedulingQuery
	{
		public SchedulingRequest Request { get; }
		public IList<SchedulingRule> Rules { get; }
		public IList<Order> Orders { get; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }


		public SchedulingQuery(SchedulingRequest request, IList<SchedulingRule> rules, IList<Order> orders)
		{
			Request = request;
			Rules = rules;
			Orders = orders;
		}
	}
}