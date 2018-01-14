using System;

namespace Behavioral.Visitor
{
	public static class LogEntryBaseEx
	{
		// functional version of visitor pattern
		public static void Match(this LogEntryBase logEntryBase, Action<ExceptionLogEntry> exceptionLogEntryMatch,
			Action<SimpleLogEntry> simpleLogEntryMatch)
		{
			var exceptionLogEntry = logEntryBase as ExceptionLogEntry;
			if (exceptionLogEntry != null)
			{
				exceptionLogEntryMatch(exceptionLogEntry);
				return;
			}

			var simpleLogEntry = logEntryBase as SimpleLogEntry;
			if (simpleLogEntry != null)
			{
				simpleLogEntryMatch(simpleLogEntry);
				return;
			}

			throw new InvalidOperationException("Unknown LogEntry type");
		}
	}
}