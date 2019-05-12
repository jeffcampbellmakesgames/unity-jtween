using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace JCMG.JTween
{
	internal struct TweenFloat3
	{
		public float3 from;
		public float3 to;

		public float3 Lerp(float ease, bool isReversed)
		{
			var currentTo = isReversed ? from : to;
			var currentFrom = isReversed ? to : from;
			return math.lerp(currentFrom, currentTo, ease);
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenFloat3>();
		}
	}
}
