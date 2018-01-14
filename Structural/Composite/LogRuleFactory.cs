using System;

namespace Structural.Composite
{
	public static class LogRuleFactory
	{
		public static LogImportRule Import(Func<LogEntryBase, bool> predicate)
		{
			return new SingleImportLogRule(predicate);
		}

		public static LogImportRule Or(this LogImportRule left, Func<LogEntryBase, bool> predicate)
		{
			LogImportRule right = Import(predicate);
			return new OrLogImportRule(left, right);
		}

		public static LogImportRule And(this LogImportRule left, Func<LogEntryBase, bool> predicate)
		{
			LogImportRule right = Import(predicate);
			return new AndLogImportRule(left, right);
		}

		public static LogImportRule LogImportRejectOldEntriesWithLowSeverity(TimeSpan period)
		{
			return Import(logEntry => logEntry is ExceptionLogEntry)
				.Or(logEntry => logEntry.OlderThan(period))
					.And(logEntry => logEntry.Severity >= Severity.Warning)
				.Or(logEntry => logEntry.Within(period));
		}

		//or OccurredWithin
		public static bool Within(this LogEntryBase logEntry, TimeSpan period) =>
			logEntry.TimeSpanFromEntryDateToNow() <= period;

		public static bool OlderThan(this LogEntryBase logEntry, TimeSpan period) =>
			logEntry.TimeSpanFromEntryDateToNow() > period;

		public static TimeSpan TimeSpanFromEntryDateToNow(this LogEntryBase logEntry)
			=> DateTime.Now - logEntry.EntryDateTime;
	}
}