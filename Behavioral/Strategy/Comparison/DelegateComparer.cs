using System;
using System.Collections.Generic;

namespace Behavioral.Strategy.Comparison
{
	public class DelegateComparer<T> : IComparer<T>
	{
		private readonly Comparison<T> _comparison;

		public DelegateComparer(Comparison<T> comparison)
		{
			_comparison = comparison;
		}

		public int Compare(T x, T y)
		{
			return _comparison(x, y);
		}
	}
}