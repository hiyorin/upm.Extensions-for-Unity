using UnityEngine;

namespace UnityExtensions
{
	public static class FloatExtensions
	{
		public static bool ApproxEquals(this float f, float f2)
		{
			return Mathf.Approximately(f, f2);
		}
	}
}
