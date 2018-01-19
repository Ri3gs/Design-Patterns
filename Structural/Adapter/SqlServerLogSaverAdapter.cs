namespace Structural.Adapter
{
	public class SqlServerLogSaverAdapter : ILogSaver
	{
		private readonly SqlServerLogSaver _sqlServerLogSaver;

		public SqlServerLogSaverAdapter(SqlServerLogSaver sqlServerLogSaver)
		{
			_sqlServerLogSaver = sqlServerLogSaver;
		}

		public void Save(LogEntry logEntry)
		{
			var simpleLogEntry = logEntry as SimpleLogEntry;
			if (simpleLogEntry != null)
			{
				_sqlServerLogSaver.Save(simpleLogEntry.EntryDateTime,
					simpleLogEntry.Severity, simpleLogEntry.Message);
				return;
			}

			var exceptionLogEntry = (ExceptionLogEntry)logEntry;
			_sqlServerLogSaver.SaveException(exceptionLogEntry.EntryDateTime,
				exceptionLogEntry.Severity, exceptionLogEntry.Message);
		}
	}
}