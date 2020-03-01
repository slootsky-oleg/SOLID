using System.Collections.Generic;
using SRP.Refactoring.SchedulingRequests;

namespace SRP.Refactoring.SchedulingRules
{
	public interface ISchedulingRulesRepository
	{
		IList<SchedulingRule> Get(Department requestDepartment);
	}
}