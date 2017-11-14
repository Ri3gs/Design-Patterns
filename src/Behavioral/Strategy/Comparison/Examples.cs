using System;
using System.Collections.Generic;

namespace Behavioral.Strategy.Comparison
{
	public class Examples
	{
		public void Example()
		{
			var employees = new List<Employee>();

			//using specific strategy
			employees.Sort(new EmployeeByIdComparer());

			//using delegate
			employees.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));


			//sometimes types accept only interfaces for specific strategies
			var set = new SortedSet<Employee>(new EmployeeByIdComparer());

			//but we can create small factory for this situations
			IComparer<Employee> comparer = ComparerFactory.Create<Employee>((x, y) => x.Id.CompareTo(y.Id));
			var set2 = new SortedSet<Employee>(comparer);
		}
	}
}
