using System;
using System.Collections.Generic;
using System.Threading;

namespace Behavioral.Observer
{
	public class LogFileReaderUsingEvents : IDisposable
	{
		private static readonly TimeSpan CheckFileInterval = TimeSpan.FromSeconds(5);
		private readonly string _logFileName;
		private readonly Timer _timer;

		public LogFileReaderUsingEvents(string logFileName)
		{
			_logFileName = logFileName;
			_timer = new Timer(CheckFile, new object(), CheckFileInterval, CheckFileInterval);
		}

		public event EventHandler<LogEntryEventArgs> OnNewLogEntry;

		private void CheckFile(object state)
		{
			foreach (var logEntry in ReadNewLogEntries())
			{
				RaiseNewLogEntry(logEntry);
			}
		}

		private void RaiseNewLogEntry(string logEntry)
		{
			EventHandler<LogEntryEventArgs> handler = OnNewLogEntry;
			if (handler != null)
				handler(this, new LogEntryEventArgs{ LogEntry = logEntry });
		}

		private IEnumerable<string> ReadNewLogEntries()
		{
			return new List<string>();
		}

		public void Dispose()
		{
			_timer.Dispose();
		}
	}
}