using System;

namespace Structural.Composite
{
	public static class LogRuleFactory
	{
		public static LogImportRule Import(Func<LogEntryBase, bool> predicate)
			=> new SingleImportLogRule(predicate);

		public static LogImportRule Or(this LogImportRule left, Func<LogEntryBase, bool> predicate)
			=> new OrLogImportRule(left, Import(predicate));

		public static LogImportRule Or(this LogImportRule left, LogImportRule right)
			=> new OrLogImportRule(left, right);

		public static LogImportRule And(this LogImportRule left, Func<LogEntryBase, bool> predicate)
			=> new AndLogImportRule(left, Import(predicate));


		public static LogImportRule RejectOldEntriesWithLowSeverity(TimeSpan period)
		{
			var oldEntriesWithHighSeverity = Import(logEntry => logEntry.OlderThan(period))
				.And(logEntry => logEntry.Severity >= Severity.Warning);

			return Import(logEntry => logEntry is ExceptionLogEntry)
				.Or(oldEntriesWithHighSeverity)
				.Or(logEntry => logEntry.Within(period));
		}
	}
}