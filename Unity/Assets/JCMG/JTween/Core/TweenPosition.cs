using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace JCMG.JTween
{
	internal struct TweenPosition
	{
		public float3 from;
		public float3 to;

		public float3 GetPosition(float ease, bool isReversed)
		{
			var currentTo = isReversed ? from : to;
			var currentFrom = isReversed ? to : from;
			return math.lerp(currentFrom, currentTo, ease);
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenPosition>();
		}
	}
}
