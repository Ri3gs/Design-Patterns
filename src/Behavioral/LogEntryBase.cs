using System;
using Behavioral.Visitor;

namespace Behavioral
{
	public abstract class LogEntryBase
	{
		public DateTime EntryDateTime { get; set; }
		public Severity Severity { get; set; }
		public string Message { get; set; }
		public string AdditionalInformation { get; set; }

		public abstract void Accept(ILogEntryVisitor logEntryVisitor);
	}
}