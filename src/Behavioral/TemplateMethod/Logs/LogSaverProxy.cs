using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Behavioral.TemplateMethod.Logs
{
	public interface ILogUploader
	{
		void UploadLogEntries(IEnumerable<LogEntry> logEntries);
		void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions);
	}

	//local template method using delegates
	public class LogUploaderProxy : ILogUploader
	{
		class LogSaverClient : ClientBase<ILogUploader>
		{
			public ILogUploader LogUploader => Channel;
		}

		public void UploadLogEntries(IEnumerable<LogEntry> logEntries)
		{
			UseProxyClient(logUploader => logUploader.UploadLogEntries(logEntries));
		}

		public void UploadExceptions(IEnumerable<ExceptionLogEntry> exceptions)
		{
			UseProxyClient(logUploader => logUploader.UploadExceptions(exceptions));
		}

		private void UseProxyClient(Action<ILogUploader> logUploaderAccessor)
		{
			var client = new LogSaverClient();

			try
			{
				logUploaderAccessor(client.LogUploader);
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