namespace Structural.Composite
{
	public abstract class ImportRule
	{
		public abstract bool ShouldImport(LogEntry logEntry);
	}
}