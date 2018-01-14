using Behavioral.Visitor;

namespace Behavioral
{
	public class SimpleLogEntry : LogEntryBase
	{
		public override void Accept(ILogEntryVisitor logEntryVisitor)
		{
			logEntryVisitor.Visit(this);
		}
	}
}