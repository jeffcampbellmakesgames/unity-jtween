using Unity.Collections.LowLevel.Unsafe;

namespace JCMG.JTween
{
	internal struct TweenTransformState
	{
		public byte isPlaying;
		public byte isMovementEnabled;
		public byte isRotationEnabled;
		public byte isScalingEnabled;
		public SpaceType moveSpaceType;
		public SpaceType rotateSpaceType;

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenTransformState>();
		}
	}
}
