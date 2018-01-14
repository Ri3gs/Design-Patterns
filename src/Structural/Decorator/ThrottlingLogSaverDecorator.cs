using System;
using System.Threading.Tasks;

namespace Structural.Decorator
{
	public class ThrottlingLogSaverDecorator : LogSaverDecorator
	{
		public ThrottlingLogSaverDecorator(ILogSaver decoratee) : base(decoratee) {}

		public override Task SaveLogEntry(string applicationId, LogEntryBase logEntry)
		{
			if (QuotaReached())
			{
				throw new QuotaReachedException(applicationId);
			}

			IncrementUsedQuota();
			return _decoratee.SaveLogEntry(applicationId, logEntry);
		}

		private void IncrementUsedQuota()
		{
			throw new NotImplementedException();
		}

		private bool QuotaReached()
		{
			throw new NotImplementedException();
		}
	}
}