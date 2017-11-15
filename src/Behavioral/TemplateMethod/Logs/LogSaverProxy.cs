using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Behavioral.TemplateMethod.Logs
{
	public interface ILogSaver
	{
		void UploadLogEntries(IEnumerable<LogEntry> logEntries);
		void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions);
	}

	//local template method using delegates
	public class LogSaverProxy : ILogSaver
	{
		class LogSaverClient : ClientBase<ILogSaver>
		{
			public ILogSaver LogSaver => Channel;
		}

		public void UploadLogEntries(IEnumerable<LogEntry> logEntries)
		{
			UseProxyClient(logSaver => logSaver.UploadLogEntries(logEntries));
		}

		public void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions)
		{
			UseProxyClient(logSaver => logSaver.UploadExceptions(exceptions));
		}

		private void UseProxyClient(Action<ILogSaver> logSaverAccessor)
		{
			var client = new LogSaverClient();

			try
			{
				logSaverAccessor(client.LogSaver);
				client.Close();
			}
			catch (Exception)
			{
				client.Abort();
				throw;
			}
		}
	}
}