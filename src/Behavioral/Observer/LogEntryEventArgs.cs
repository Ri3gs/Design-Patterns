using System;

namespace Behavioral.Observer
{
	public class LogEntryEventArgs : EventArgs
	{
		public string LogEntry { get; internal set; }
	}
}