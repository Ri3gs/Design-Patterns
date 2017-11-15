using System.Collections.Generic;
using System.Linq;

namespace Behavioral.TemplateMethod.Logs
{
	//template method using inheritance
	public abstract class LogReader
	{
		private int _currentPosition;

		public IEnumerable<LogEntry> ReadLogEntries()
		{
			return ReadEntries(ref _currentPosition).Select(ParseLogEntry);
		}

		protected abstract IEnumerable<string> ReadEntries(ref int position);

		protected abstract LogEntry ParseLogEntry(string stringEntry);
	}
}