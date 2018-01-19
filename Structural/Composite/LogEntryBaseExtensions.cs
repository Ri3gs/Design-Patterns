using System;

namespace Structural.Composite
{
	public static class LogEntryBaseExtensions
	{
		//or OccurredWithin
		public static bool Within(this LogEntry logEntry, TimeSpan period) =>
			logEntry.TimeSpanFromEntryDateToNow() <= period;

		public static bool OlderThan(this LogEntry logEntry, TimeSpan period) =>
			logEntry.TimeSpanFromEntryDateToNow() > period;

		public static TimeSpan TimeSpanFromEntryDateToNow(this LogEntry logEntry)
			=> DateTime.Now - logEntry.EntryDateTime;
	}
}