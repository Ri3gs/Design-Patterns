using System.Linq;

namespace Structural.Composite
{
	public class OrRule : CompositeRule
	{
		public OrRule(ImportRule left, ImportRule right) : base(new []{left, right}) {}

		public override bool ShouldImport(LogEntry logEntry) =>
			Rules.Any(rule => rule.ShouldImport(logEntry));
	}
}