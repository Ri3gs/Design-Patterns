using System;

namespace Structural.Composite
{
	public class SingleImportLogRule : LogImportRule
	{
		private readonly Func<LogEntryBase, bool> _predicate;

		public SingleImportLogRule(Func<LogEntryBase, bool> predicate)
		{
			_predicate = predicate;
		}

		public override bool ShouldImport(LogEntryBase logEntry)
		{
			return _predicate(logEntry);
		}
	}
}