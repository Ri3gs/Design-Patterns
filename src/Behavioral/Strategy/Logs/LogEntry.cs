using System;

namespace Behavioral.Strategy.Logs
{
	public class LogEntry
	{
		public DateTime DateTime { get; set; }
		public Severity Severity { get; set; }
		public string Message { get; set; }
	}

	public enum Severity
	{
		Error,
		Information
	}
}