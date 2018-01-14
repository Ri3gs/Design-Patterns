namespace Behavioral.Observer
{
	public interface ILogFileReaderObserver
	{
		void NewEntry(string logEntry);
		void FileWasRolled(string oldLogFile, string newLogFile);
	}
}