using System.Linq;

namespace Structural.Composite
{
	public class AndRule : CompositeRule
	{
		public AndRule(ImportRule left, ImportRule right) : base(new[]{left, right}) {}

		public override bool ShouldImport(LogEntry logEntry) =>
			Rules.All(rule => rule.ShouldImport(logEntry));
	}
}