using Behavioral.Strategy.Logs;

namespace Behavioral.Meidator
{
	//altho canonical examples suggest us inheritance in most cases that is not the case
	public class LogFileImporter
	{
		private readonly ILogReader _logReader;
		private readonly ILogSaver _logSaver;

		public LogFileImporter(ILogReader logReader, ILogSaver logSaver)
		{
			_logReader = logReader;
			_logSaver = logSaver;
		}

		public void ImportLog(string fileName)
		{
			foreach (var logEntry in _logReader.Read())
			{
				_logSaver.Save(logEntry);
			}
		}
	}
}