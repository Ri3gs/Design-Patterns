using System.Threading.Tasks;

namespace Structural.Decorator
{
	public class ElasticSearchLogSaver : ILogSaver
	{
		public Task SaveLogEntry(string applicationId, LogEntryBase logEntry)
		{
			return Task.FromResult<object>(null);
		}
	}
}