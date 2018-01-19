using System;
using Structural.Adapter;

namespace Structural
{
	public abstract class LogEntry
	{
		public DateTime EntryDateTime { get; set; }
		public Severity Severity { get; set; }
		public string Message { get; set; }
		public string AdditionalInformation { get; set; }
	}
}