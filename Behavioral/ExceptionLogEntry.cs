using System;
using Behavioral.Visitor;

namespace Behavioral
{
	public class ExceptionLogEntry : LogEntryBase
	{
		public Exception Exception { get; set; }
		public override void Accept(ILogEntryVisitor logEntryVisitor)
		{
			logEntryVisitor.Visit(this);
		}
	}
}