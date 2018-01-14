using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Behavioral.Observer
{
	public class LogFileReaderUsingIObservable : IDisposable
	{
		private readonly string _fileName;
		private readonly Subject<string> _logEntriesSubject = new Subject<string>();

		public LogFileReaderUsingIObservable(string fileName)
		{
			_fileName = fileName;
		}

		public void Dispose()
		{
			// notify subscribers that there will be no more events
			_logEntriesSubject.OnCompleted();

			CloseFile();
			_logEntriesSubject?.Dispose();
		}

		public IObservable<string> NewMessages => _logEntriesSubject;

		private void CheckFile()
		{
			foreach (var logEntry in ReadNewLogEntries())
			{
				_logEntriesSubject.OnNext(logEntry);
			}
		}

		private IEnumerable<string> ReadNewLogEntries()
		{
			throw new NotImplementedException();
		}

		private void CloseFile()
		{
			throw new NotImplementedException();
		}
	}

	public class Client
	{
		public void UsageOfLogFileReaderUsingIObservable()
		{
			var logFileReader = new LogFileReaderUsingIObservable(string.Empty);

			// now we can use LINQ syntax
			var messagesObservable = logFileReader.NewMessages
				.Select(ParseLogMessages)
				.Where(m => m.Severity == Severity.Critical);

			messagesObservable.Buffer(10)
				.Subscribe(BulkSaveMessages);
		}

		private void BulkSaveMessages(IList<LogEntry> criticalMessages)
		{
			throw new NotImplementedException();
		}

		private LogEntry ParseLogMessages(string arg)
		{
			return new LogEntry();
		}
	}
}