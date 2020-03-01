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

		private readonly ISchedulingResponseRepository responseRepository;

		public SchedulingResponseSaver(ISchedulingResponseRepository responseRepository)
		{
			this.responseRepository = responseRepository;
		}

		public void SaveResponse(SchedulingResponse response)
		{
			Policy
				.Handle<SqlException>(IsDeadLock)
				.WaitAndRetry(RetryCount, SleepDurationProvider())
				.Execute(() => responseRepository.Save(response));
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