namespace Behavioral.Visitor
{
	public interface ILogEntryVisitor
	{
		void Visit(ExceptionLogEntry exceptionLogEntry);
		void Visit(SimpleLogEntry simpleLogEntry);
	}
}