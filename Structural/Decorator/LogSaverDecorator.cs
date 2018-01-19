using System.Threading.Tasks;

namespace Structural.Decorator
{
	public abstract class LogSaverDecorator : ILogSaver
	{
		protected readonly ILogSaver _decoratee;

		protected LogSaverDecorator(ILogSaver decoratee)
		{
			_decoratee = decoratee;
		}

		public abstract Task SaveLogEntry(string applicationId, LogEntry logEntry);
	}
}