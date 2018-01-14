using System;

namespace Structural.Adapter
{
	public class SqlServerLogSaver
	{
		public void Save(DateTime logEntryDateTime, Severity logEntrySeverity, string message)
		{
			// save to some storage
		}

		public void SaveException(DateTime logEntryDateTime, Severity logEntrySeverity, string message)
		{
			// save to special table
		}
	}
}