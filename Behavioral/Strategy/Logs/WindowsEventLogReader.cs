using System.Collections.Generic;

namespace Behavioral.Strategy.Logs
{
	public class WindowsEventLogReader : ILogReader
	{
		public List<LogEntry> Read()
		{
			throw new System.NotImplementedException();
		}
	}
}