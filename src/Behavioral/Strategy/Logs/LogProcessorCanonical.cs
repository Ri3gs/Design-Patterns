using System.Collections.Generic;

namespace Behavioral.Strategy.Logs
{
	public class LogProcessorCanonical
	{
		private readonly ILogReader _logReader;

		public LogProcessorCanonical(ILogReader logReader)
		{
			_logReader = logReader;
		}

		public void ProcessLogs()
		{
			List<LogEntry> logEntries = _logReader.Read();
			// Process somehow
		}
	}
}