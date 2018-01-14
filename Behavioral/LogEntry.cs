using Behavioral.Visitor;

namespace Behavioral
{
	public class LogEntry : LogEntryBase
	{
		public static LogEntry Parse(string line)
		{
			throw new System.NotImplementedException();
		}

		public override void Accept(ILogEntryVisitor logEntryVisitor)
		{
			throw new System.NotImplementedException();
		}
	}
}