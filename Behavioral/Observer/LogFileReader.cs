using System;
using System.Collections.Generic;
using System.Threading;

namespace Behavioral.Observer
{
	public class LogFileReader : IDisposable
	{
		private readonly string _logFile;
		private readonly Action<string> _logEntrySubscriber;
		private static readonly TimeSpan CheckFileInterval = TimeSpan.FromSeconds(5);
		private readonly Timer _timer;

		public LogFileReader(string logFile, Action<string> logEntrySubscriber)
		{
			_logFile = logFile;
			_logEntrySubscriber = logEntrySubscriber;
			_timer = new Timer(CheckFile, new object(), CheckFileInterval, CheckFileInterval);
		}

		public void Dispose()
		{
			_timer.Dispose();
		}

		private void CheckFile(object state)
		{
			foreach (var logEntry in ReadNewLogEntries())
			{
				_logEntrySubscriber(logEntry);
			}
		}

		private IEnumerable<string> ReadNewLogEntries()
		{
			// Read new records from file
			// that appeared from last read
			return new List<string>();
		}
	}
}