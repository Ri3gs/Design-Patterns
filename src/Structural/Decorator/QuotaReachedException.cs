using System;

namespace Structural.Decorator
{
	public class QuotaReachedException : Exception
	{
		public string ApplicationId { get; }

		public QuotaReachedException(string applicationId)
		{
			ApplicationId = applicationId;
		}
	}
}