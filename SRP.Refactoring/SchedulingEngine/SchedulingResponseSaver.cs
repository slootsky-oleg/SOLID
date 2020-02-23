using System;
using System.Data.SqlClient;
using Polly;
using SRP.Refactoring.SchedulingRequests;

namespace SRP.Refactoring.SchedulingEngine
{
	public class SchedulingResponseSaver
	{
		private const int RetryCount = 3;
		private const int SleepSeconds = 5;

		private readonly ISchedulingRequestRepository schedulingRequestRepository;

		public SchedulingResponseSaver(ISchedulingRequestRepository schedulingRequestRepository)
		{
			this.schedulingRequestRepository = schedulingRequestRepository;
		}

		public void SaveResponse(SchedulingResponse response)
		{
			Policy
				.Handle<SqlException>(IsDeadLock)
				.WaitAndRetry(RetryCount, SleepDurationProvider())
				.Execute(() => schedulingRequestRepository.Save(response));
		}

		private static bool IsDeadLock(SqlException ex)
		{
			return ex.Number == 1205;
		}

		private static Func<int, TimeSpan> SleepDurationProvider()
		{
			return sleep => TimeSpan.FromSeconds(SleepSeconds);
		}
	}
}