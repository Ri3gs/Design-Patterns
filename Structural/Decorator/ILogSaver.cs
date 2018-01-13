using System.Threading.Tasks;

namespace Structural.Decorator
{
	public interface ILogSaver
	{
		Task SaveLogEntry(string applicationId, LogEntryBase logEntry);
	}
}