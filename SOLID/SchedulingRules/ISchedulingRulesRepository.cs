using System.Collections.Generic;

namespace SOLID.SchedulingRules
{
	internal interface ISchedulingRulesRepository
	{
		IList<SchedulingRule> GetAll();
	}
}