using System.Threading.Tasks;

namespace Structural.Decorator
{
	public class ElasticSearchLogSaver : ILogSaver
	{
		public Task SaveLogEntry(string applicationId, LogEntry logEntry)
		{
			return Task.FromResult<object>(null);
		}
	}
}