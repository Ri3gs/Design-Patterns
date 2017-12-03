namespace Behavioral.Visitor
{
	public class DatabaseLogSaverIf
	{
		public void SaveLogEntry(LogEntryBase logEntry)
		{
			var exception = logEntry as ExceptionLogEntry;
			if (exception != null)
			{
				SaveException(exception);
			}
			else
			{
				var simpleLogEntry = logEntry as SimpleLogEntry;
				if (simpleLogEntry != null)
				{
					SaveSimpleLogEntry(simpleLogEntry);
				}
			}
		}
		private void SaveSimpleLogEntry(SimpleLogEntry simpleLogEntry)
		{
			throw new System.NotImplementedException();
		}
		private void SaveException(ExceptionLogEntry exception)
		{
			throw new System.NotImplementedException();
		}
	}

	public class DatabaseLogSaverVisitor : ILogEntryVisitor
	{
		public void SaveLogEntry(LogEntryBase logEntry)
		{
			logEntry.Accept(this);
		}

		public void Visit(ExceptionLogEntry exceptionLogEntry)
		{
			SaveException(exceptionLogEntry);
		}

		public void Visit(SimpleLogEntry simpleLogEntry)
		{
			SaveSimpleLogEntry(simpleLogEntry);
		}

		private void SaveSimpleLogEntry(SimpleLogEntry simpleLogEntry)
		{
			throw new System.NotImplementedException();
		}
		private void SaveException(ExceptionLogEntry exception)
		{
			throw new System.NotImplementedException();
		}
	}
}