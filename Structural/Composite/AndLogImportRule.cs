using System.Linq;

namespace Structural.Composite
{
	public class AndLogImportRule : CompositeLogRule
	{
		public AndLogImportRule(LogImportRule left, LogImportRule right) : base(new[]{left, right}) {}

		public override bool ShouldImport(LogEntryBase logEntry) =>
			Rules.All(rule => rule.ShouldImport(logEntry));
	}
}