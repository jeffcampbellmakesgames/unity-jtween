using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace JCMG.JTween
{
	internal struct TweenFloat1
	{
		public float from;
		public float to;

		public float Lerp(float ease, bool isReversed)
		{
			var currentTo = isReversed ? from : to;
			var currentFrom = isReversed ? to : from;
			return math.lerp(currentFrom, currentTo, ease);
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenFloat1>();
		}
	}
}
