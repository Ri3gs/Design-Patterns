namespace Structural.Composite
{
	public abstract class LogImportRule
	{
		public abstract bool ShouldImport(LogEntryBase logEntry);
	}
}