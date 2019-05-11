using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace JCMG.JTween
{
	internal struct TweenFloat4
	{
		public float4 from;
		public float4 to;

		public float4 Lerp(float ease, bool isReversed)
		{
			var currentTo = isReversed ? from : to;
			var currentFrom = isReversed ? to : from;
			return math.lerp(currentFrom, currentTo, ease);
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenFloat4>();
		}
	}
}
