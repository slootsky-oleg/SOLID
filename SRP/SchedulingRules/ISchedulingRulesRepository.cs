using System.Collections.Generic;

namespace SOLID.SchedulingRules
{
	public interface ISchedulingRulesRepository
	{
		IList<SchedulingRule> GetAll();
	}
}