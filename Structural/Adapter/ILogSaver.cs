namespace Structural.Adapter
{
	public interface ILogSaver
	{
		void Save(LogEntryBase logEntry);
	}
}