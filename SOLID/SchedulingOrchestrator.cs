using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.Optimizations;
using SOLID.SchedulingEngine;
using SOLID.SchedulingRules;

namespace SOLID
{
    public class SchedulingOrchestrator
    {
	    private readonly IOptimizationRepository optimizationRepository;
	    private readonly ISchedulingRulesRepository schedulingRulesRepository;
	    private readonly ISchedulingResponseRepository schedulingResponseRepository;
	    private readonly ISchedulingRequestBuilder requestBuilder;
	    private readonly ISchedulingEngine schedulingEngine;

	    public void Schedule(long optimizationId)
	    {
		    var optimization = optimizationRepository.GetById(optimizationId)
		                  ?? throw new OptimizationNotFoundException(optimizationId);

		    if (optimization.Orders?.Any() != true)
		    {
			    throw new InvalidOptimizationException(optimizationId, "Request must contain orders.");
		    }

		    if (optimization.End >= DateTime.Now)
		    {
			    throw new InvalidOptimizationException(optimizationId, "Optimization must be active.");
		    }

		    var rules = schedulingRulesRepository.GetAll();
		    var requiredRules = rules
			    .Where(r => r.Department == optimization.Department)
			    .ToList();

		    var schedulingRequest = requestBuilder.Build(optimization, requiredRules);
		    schedulingRequest.Start = optimization.Start;
		    schedulingRequest.End = optimization.End;

		    try
		    {
			    var schedulingResponse = schedulingEngine.Schedule(schedulingRequest);
			    schedulingResponseRepository.Save(schedulingResponse);
		    }
		    catch (Exception e)
		    {
			    //try again
			    try
			    {
				    var schedulingResponse = schedulingEngine.Schedule(schedulingRequest);
				    schedulingResponseRepository.Save(schedulingResponse);
			    }
			    catch (Exception exception)
			    {
			    }
		    }
	    }
    }
}
