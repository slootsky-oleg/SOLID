using System.Collections.Generic;

namespace SRP.Refactoring.SchedulingRules
{
	public interface ISchedulingRulesRepository
	{
		IList<SchedulingRule> GetAll();
	}
}