using System.Collections.Generic;
using SOLID.Optimizations;
using SOLID.SchedulingRules;

namespace SOLID.SchedulingEngine
{
	internal interface ISchedulingRequestBuilder
	{
		SchedulingRequest Build(Optimization optimization, List<SchedulingRule> requiredRules);
	}
}