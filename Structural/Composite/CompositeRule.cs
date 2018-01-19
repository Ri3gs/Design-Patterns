namespace Structural.Composite
{
	public abstract class CompositeRule : ImportRule
	{
		protected readonly ImportRule[] Rules;

		protected CompositeRule(ImportRule[] rules)
		{
			Rules = rules;
		}

		public abstract override bool ShouldImport(LogEntry logEntry);
	}
}