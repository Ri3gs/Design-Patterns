using System;
using System.Threading;

namespace Behavioral.Observer
{
	public class LogFileReaderUsingStronglyTypedObserver : IDisposable
	{
		private static readonly TimeSpan CheckFileInterval = TimeSpan.FromSeconds(5);
		private readonly ILogFileReaderObserver _logFileReaderObserver;
		private readonly string _logFileName;
		private readonly Timer _timer;

		public LogFileReaderUsingStronglyTypedObserver(ILogFileReaderObserver logFileReaderObserver, string logFileName)
		{
			_logFileReaderObserver = logFileReaderObserver;
			_logFileName = logFileName;
			_timer = new Timer(DetectThatNewFileWasCreated, new object(), CheckFileInterval, CheckFileInterval);
		}

		// added new logic that checks that logger stopped writing to current log file
		// and switched to new one

		private void DetectThatNewFileWasCreated(object state)
		{
			// this method is called via timer
			if (NewLogFileWasCreated())
			{
				_logFileReaderObserver.FileWasRolled(_logFileName, GetNewLogFileName());
			}
		}

		private string GetNewLogFileName()
		{
			throw new System.NotImplementedException();
		}

		private bool NewLogFileWasCreated()
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			_timer?.Dispose();
		}
	}
}