using System;
using System.Collections.Generic;

namespace Behavioral.Iterator
{
	//using iterator to write simple foreach extension
	public static class EnumerableExtension
	{
		public static void MyForEach<T>(this IEnumerable<T> sequence, Action<T> action)
		{
			IEnumerator<T> enumerator = sequence.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					action(current);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}
}