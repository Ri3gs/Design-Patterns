using System;
using System.Collections.Generic;

namespace Behavioral.Strategy.Comparison
{
	public class ComparerFactory
	{
		public static IComparer<T> Create<T>(Comparison<T> comparison)
		{
			return new DelegateComparer<T>(comparison);
		}
	}
}