﻿using System;
using System.Collections.Generic;

namespace SOLID.SchedulingRequests
{
	public class SchedulingRequest
	{
		public IList<Order> Orders { get; set; }
		public Department Department { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}