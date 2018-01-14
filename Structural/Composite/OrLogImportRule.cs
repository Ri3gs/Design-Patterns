using System.Linq;

namespace Structural.Composite
{
	public class OrLogImportRule : CompositeLogRule
	{
		public OrLogImportRule(LogImportRule left, LogImportRule right) : base(new []{left, right}) {}

		public override bool ShouldImport(LogEntryBase logEntry)
		{
			return Rules.Any(rule => rule.ShouldImport(logEntry));
		}
	}
}