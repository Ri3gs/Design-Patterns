using System;

namespace Structural.Composite
{
	public static class RuleFactory
	{
		public static ImportRule Import(Func<LogEntry, bool> predicate)
			=> new SingleRule(predicate);

		public static ImportRule Or(this ImportRule left, Func<LogEntry, bool> predicate)
			=> new OrRule(left, Import(predicate));

		public static ImportRule Or(this ImportRule left, ImportRule right)
			=> new OrRule(left, right);

		public static ImportRule And(this ImportRule left, Func<LogEntry, bool> predicate)
			=> new AndRule(left, Import(predicate));


		public static ImportRule RejectOldEntriesWithLowSeverity(TimeSpan period)
		{
			var oldEntriesWithHighSeverity = Import(logEntry => logEntry.OlderThan(period))
				.And(logEntry => logEntry.Severity >= Severity.Warning);

			return Import(logEntry => logEntry is ExceptionLogEntry)
				.Or(oldEntriesWithHighSeverity)
				.Or(logEntry => logEntry.Within(period));
		}
	}
}