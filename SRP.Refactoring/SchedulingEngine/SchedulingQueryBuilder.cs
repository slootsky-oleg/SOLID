using System.Collections.Generic;
using SRP.Refactoring.SchedulingRequests;
using SRP.Refactoring.SchedulingRules;

namespace SRP.Refactoring.SchedulingEngine
{
	public class SchedulingQueryBuilder
	{
		public SchedulingQuery Build(SchedulingRequest request, IList<SchedulingRule> rules)
		{
			//some building logic
			return new SchedulingQuery(request, rules)
			{
				Start = request.Start,
				End = request.End
			};
		}
	}
}