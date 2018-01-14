namespace Structural.Composite
{
	public abstract class CompositeLogRule : LogImportRule
	{
		protected readonly LogImportRule[] Rules;

		protected CompositeLogRule(LogImportRule[] rules)
		{
			Rules = rules;
		}

		public abstract override bool ShouldImport(LogEntryBase logEntry);
	}
}