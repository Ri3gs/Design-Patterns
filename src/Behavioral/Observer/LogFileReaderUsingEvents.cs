using System;
using System.Collections.Generic;
using System.Threading;

namespace Behavioral.Observer
{
	public class LogFileReaderUsingEvents : IDisposable
	{
		private static readonly TimeSpan CheckFileInterval = TimeSpan.FromSeconds(5);
		private readonly Timer _timer;

		public LogFileReaderUsingEvents(string logFileName)
		{
			LogFileName = logFileName;
			_timer = new Timer(CheckFile, new object(), CheckFileInterval, CheckFileInterval);
		}

		// but observers can 'pull' additional information
		public readonly string LogFileName;
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
			// we 'push' only necessary information
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

	public class LogForwarder
	{
		public LogForwarder(LogFileReaderUsingEvents logFileReaderUsingEvents)
		{
			logFileReaderUsingEvents.OnNewLogEntry += HandleNewEntry;
		}

		private void HandleNewEntry(object sender, LogEntryEventArgs logEntryEventArgs)
		{
			var logEntry = logEntryEventArgs.LogEntry;
			var logFileName = ((LogFileReaderUsingEvents) sender).LogFileName;

			// process logEntry considering logFileName
		}
	}
}