using System;

namespace Structural.Composite
{
	public static class LogEntryBaseExtensions
	{
		//or OccurredWithin
		public static bool Within(this LogEntryBase logEntry, TimeSpan period) =>
			logEntry.TimeSpanFromEntryDateToNow() <= period;

		public static bool OlderThan(this LogEntryBase logEntry, TimeSpan period) =>
			logEntry.TimeSpanFromEntryDateToNow() > period;

		public static TimeSpan TimeSpanFromEntryDateToNow(this LogEntryBase logEntry)
			=> DateTime.Now - logEntry.EntryDateTime;
	}
}