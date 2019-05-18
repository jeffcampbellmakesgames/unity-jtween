using Unity.Collections.LowLevel.Unsafe;

namespace JCMG.JTween
{
	internal struct TweenTransformState
	{
		public TweenStateType state;
		public TweenTransformType transformType;
		public TweenSpaceType spaceType;

		public bool IsPlaying()
		{
			return (state & TweenStateType.IsPlaying) == TweenStateType.IsPlaying;
		}

		public bool IsPaused()
		{
			return (state & TweenStateType.IsPaused) == TweenStateType.IsPaused;
		}

		public bool IsCompleted()
		{
			return (state & TweenStateType.IsCompleted) == TweenStateType.IsCompleted;
		}

		public bool HasHandle()
		{
			return (state & TweenStateType.HasHandle) == TweenStateType.HasHandle;
		}

		public bool JustStarted()
		{
			return (state & TweenStateType.JustStarted) == TweenStateType.JustStarted;
		}

		public bool JustEnded()
		{
			return (state & TweenStateType.JustEnded) == TweenStateType.JustEnded;
		}

		public bool RequiresRecycling()
		{
			return (state & TweenStateType.RequiresRecycling) == TweenStateType.RequiresRecycling;
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

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenTransformState>();
		}
	}
}
