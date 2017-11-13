using System.Collections.Generic;

namespace Behavioral.Strategy.Logs
{
	public interface ILogReader
	{
		List<LogEntry> Read();
	}
}