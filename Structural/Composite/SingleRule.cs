using System;

namespace Structural.Composite
{
	public class SingleRule : ImportRule
	{
		private readonly Func<LogEntry, bool> _predicate;

		public SingleRule(Func<LogEntry, bool> predicate)
		{
			_predicate = predicate;
		}

		public override bool ShouldImport(LogEntry logEntry)
		{
			return _predicate(logEntry);
		}
	}
}