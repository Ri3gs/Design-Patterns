using System;
using System.Collections.Generic;

namespace Behavioral.Strategy.Logs
{
	public class LogProcessorDelegate
	{
		private readonly Func<List<LogEntry>> _logImporter;

		public LogProcessorDelegate(Func<List<LogEntry>> logImporter)
		{
			_logImporter = logImporter;
		}

		public void ProcessLogs()
		{
			List<LogEntry> logEntries = _logImporter.Invoke();
			// Process somehow
		}
	}
}