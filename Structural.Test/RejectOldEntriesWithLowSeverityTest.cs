using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structural.Composite;

namespace Structural.Test
{
	[TestClass]
	public class RejectOldEntriesWithLowSeverityTest
	{
		private ImportRule _rule;

		[TestInitialize]
		public void Initialize()
		{
			_rule = RuleFactory.RejectOldEntriesWithLowSeverity(TimeSpan.FromDays(7));
		}

		[TestMethod]
		public void ImportsExceptionEntry()
		{
			// Arrange
			var logEntry = new ExceptionLogEntry();

			// Assert
			Assert.IsTrue(_rule.ShouldImport(logEntry));
		}

		[TestMethod]
		public void RejectsOldEntryWithLowSeverity()
		{
			// Arrange
			var logEntry = new SimpleLogEntry
			{
				EntryDateTime = DateTime.Now.AddDays(-10)
			};

			// Assert
			Assert.IsFalse(_rule.ShouldImport(logEntry));
		}

		[TestMethod]
		public void ImportsOldEntryWithHighSeverity()
		{
			// Arrange
			var logEntry = new SimpleLogEntry
			{
				EntryDateTime = DateTime.Now.AddDays(-10),
				Severity = Severity.Critical
			};

			// Assert
			Assert.IsTrue(_rule.ShouldImport(logEntry));
		}

		[TestMethod]
		public void ImportsEntryWithinSpecifiedTimeSpan()
		{
			// Arrange
			var logEntry = new SimpleLogEntry
			{
				EntryDateTime = DateTime.Now.AddDays(-5)
			};

			// Assert
			Assert.IsTrue(_rule.ShouldImport(logEntry));
		}
	}
}
