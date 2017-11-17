using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Behavioral.Iterator;

namespace Tests
{
	[TestClass]
	public class EnumerableExtensionTest
	{
		[TestMethod]
		public void SimpleTest()
		{
			// Arrange
			var testthingy = new List<int> { 1, 2, 3, 4, 5 };
			var expected = 1;
			testthingy.ForEach(number => { expected *= number; });

			// Act
			var actual = 1;
			testthingy.MyForEach(number => { actual *= number; });

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
