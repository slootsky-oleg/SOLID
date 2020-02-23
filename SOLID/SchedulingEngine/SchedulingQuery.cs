﻿using System;
using System.Collections.Generic;
using SOLID.SchedulingRequests;
using SOLID.SchedulingRules;

namespace SOLID.SchedulingEngine
{
	public class SchedulingQuery
	{
		public SchedulingRequest SchedulingRequest { get; }
		public IList<SchedulingRule> RequiredRules { get; }
		public IList<Order> RequestOrders { get; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }


		public SchedulingQuery(SchedulingRequest schedulingRequest, IList<SchedulingRule> requiredRules, IList<Order> requestOrders)
		{
			SchedulingRequest = schedulingRequest;
			RequiredRules = requiredRules;
			RequestOrders = requestOrders;
		}
	}
}