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

		public bool IsRotationXYZ()
		{
			return (spaceType & TweenSpaceType.RotateModeXYZ) == TweenSpaceType.RotateModeXYZ;
		}

		public bool IsRotationX()
		{
			return (spaceType & TweenSpaceType.RotateX) == TweenSpaceType.RotateX;
		}

		public bool IsRotationY()
		{
			return (spaceType & TweenSpaceType.RotateY) == TweenSpaceType.RotateY;
		}

		public bool IsRotationZ()
		{
			return (spaceType & TweenSpaceType.RotateZ) == TweenSpaceType.RotateZ;
		}

		public RotateMode GetRotateMode()
		{
			var rotateMode = RotateMode.XYZ;
			if (IsRotationX())
			{
				rotateMode = RotateMode.X;
			}
			else if (IsRotationY())
			{
				rotateMode = RotateMode.Y;
			}
			else if (IsRotationZ())
			{
				rotateMode = RotateMode.Z;
			}

			return rotateMode;
		}
	}
}
