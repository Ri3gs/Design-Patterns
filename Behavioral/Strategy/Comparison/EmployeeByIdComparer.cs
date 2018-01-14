using System.Collections.Generic;

namespace Behavioral.Strategy.Comparison
{
	public class EmployeeByIdComparer : IComparer<Employee>
	{
		public int Compare(Employee x, Employee y)
		{
			return x.Id.CompareTo(y.Id);
		}
	}
}