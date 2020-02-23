using System;
using System.Net;
using Polly;

namespace SRP.Refactoring.SchedulingEngine
{
	public class SchedulingExecutor
	{
		private const int RetryCount = 3;
		private const int SleepSeconds = 5;

		private readonly ISchedulingEngine schedulingEngine;

		public SchedulingExecutor(ISchedulingEngine schedulingEngine)
		{
			this.schedulingEngine = schedulingEngine;
		}

		public SchedulingResponse Schedule(SchedulingQuery query)
		{
			return Policy<SchedulingResponse>
				.Handle<WebException>()
				.WaitAndRetry(RetryCount, SleepDurationProvider())
				.Execute(() => schedulingEngine.Schedule(query));
		}

		private static Func<int, TimeSpan> SleepDurationProvider()
		{
			//add multiplier?
			return sleep => TimeSpan.FromSeconds(SleepSeconds);
		}
	}
}