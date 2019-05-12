using Unity.Collections.LowLevel.Unsafe;

namespace JCMG.JTween
{
	internal struct TweenTransformState
	{
		public byte isPlaying;
		public TweenTransformType transformType;
		public TweenSpaceType spaceType;

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenTransformState>();
		}

		public bool IsMovementInWorldSpace()
		{
			return (spaceType & TweenSpaceType.WorldMovement) == TweenSpaceType.WorldMovement;
		}

		public bool IsRotationInWorldSpace()
		{
			return (spaceType & TweenSpaceType.WorldRotation) == TweenSpaceType.WorldRotation;
		}

		public bool IsMovementEnabled()
		{
			return (transformType & TweenTransformType.Movement) == TweenTransformType.Movement;
		}

		public bool IsRotationEnabled()
		{
			return (transformType & TweenTransformType.Rotation) == TweenTransformType.Rotation;
		}

		public bool IsScalingEnabled()
		{
			return (transformType & TweenTransformType.Scaling) == TweenTransformType.Scaling;
		}
	}
}
