using System.Collections.Generic;
using SRP.Refactoring.SchedulingRequests;

namespace SRP.Refactoring.SchedulingRules
{
	public class SchedulingRulesStore
	{
		private readonly ISchedulingRulesRepository rulesRepository;

		public SchedulingRulesStore(ISchedulingRulesRepository rulesRepository)
		{
			this.rulesRepository = rulesRepository;
		}

		public IList<SchedulingRule> Get(SchedulingRequest request)
		{
			return rulesRepository.Get(request.Department);

			//Additional logic can be placed here
		}
	}
}