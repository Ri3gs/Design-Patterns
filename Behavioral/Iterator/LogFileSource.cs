using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Behavioral.Iterator
{
	//example with reading&parsing logs
	public class LogFileSource : IEnumerable<LogEntry>
	{
		private readonly string _logFileName;

		public LogFileSource(string logFileName)
		{
			_logFileName = logFileName;
		}

		public IEnumerator<LogEntry> GetEnumerator()
		{
			foreach (var line in File.ReadAllLines(_logFileName))
			{
				yield return LogEntry.Parse(line);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public class Consumer
	{
		public void Loop()
		{
			var logFileSource = new LogFileSource(String.Empty);

			foreach (var logEntry in logFileSource)
			{
				Console.WriteLine(logEntry.Message);
			}

			while (logFileSource.GetEnumerator().MoveNext())
			{
				Console.WriteLine(logFileSource.GetEnumerator().Current.Message);
			}
		}
	}
}