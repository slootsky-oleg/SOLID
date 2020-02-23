using System.Collections.Generic;
using System.Linq;
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

		public List<SchedulingRule> Get(SchedulingRequest request)
		{
			var rules = rulesRepository.GetAll();

			return rules
				.Where(r => r.Department == request.Department)
				.ToList();
		}
	}
}