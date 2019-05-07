using Unity.Mathematics;
using UnityEngine;

namespace JCMG.JTween
{
	public sealed partial class JTweenControl
	{
		public void Move(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_transforms.Add(target);
			_transformAccessArray.Add(target);

			_tweenStates.Add(new TweenTransformState
			{
				isPlaying = TRUE,
				isMovementEnabled = TRUE,
				moveSpaceType = spaceType
			});

			_tweenPositions.Add(new TweenPosition {from = from, to = to});
			_tweenRotations.Add(new TweenRotation());
			_tweenScales.Add(new TweenScale());

			_tweenPositionLifetimes.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_tweenRotationLifetimes.Add(new TweenLifetime());
			_tweenScaleLifetimes.Add(new TweenLifetime());
		}

		public void Scale(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_transforms.Add(target);
			_transformAccessArray.Add(target);

			_tweenStates.Add(new TweenTransformState {isPlaying = TRUE, isScalingEnabled = TRUE});

			_tweenPositions.Add(new TweenPosition());
			_tweenRotations.Add(new TweenRotation());
			_tweenScales.Add(new TweenScale {from = from, to = to});

			_tweenPositionLifetimes.Add(new TweenLifetime());
			_tweenRotationLifetimes.Add(new TweenLifetime());
			_tweenScaleLifetimes.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
		}

		public void Rotate(
			Transform target,
			Quaternion from,
			Quaternion to,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_transforms.Add(target);
			_transformAccessArray.Add(target);

			_tweenStates.Add(new TweenTransformState
			{
				isPlaying = TRUE,
				isRotationEnabled = TRUE,
				rotateSpaceType = spaceType
			});

			_tweenPositions.Add(new TweenPosition());
			_tweenRotations.Add(new TweenRotation
			{
				from = from, to = to,
				rotateMode = RotateMode.XYZ
			});
			_tweenScales.Add(new TweenScale());

			_tweenPositionLifetimes.Add(new TweenLifetime());
			_tweenRotationLifetimes.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_tweenScaleLifetimes.Add(new TweenLifetime());
		}

		public void RotateX(
			Transform target,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			RotateOnAxis(
				target,
				angle,
				duration,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				RotateMode.X);
		}

		public void RotateY(
			Transform target,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			RotateOnAxis(
				target,
				angle,
				duration,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				RotateMode.Y);
		}

		public void RotateZ(
			Transform target,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			RotateOnAxis(
				target,
				angle,
				duration,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				RotateMode.Z);
		}

		internal void RotateOnAxis(
			Transform target,
			float angle,
			float duration,
			SpaceType spaceType,
			EaseType easeType,
			LoopType loopType,
			int loopCount,
			RotateMode rotateMode)
		{
			_transforms.Add(target);
			_transformAccessArray.Add(target);

			_tweenStates.Add(new TweenTransformState
			{
				isPlaying = TRUE,
				isRotationEnabled = TRUE,
				rotateSpaceType = spaceType
			});

			_tweenPositions.Add(new TweenPosition());

			var eulerAngles = spaceType == SpaceType.World
				? target.eulerAngles
				: target.localEulerAngles;

			_tweenRotations.Add(new TweenRotation {
				from = new quaternion(eulerAngles.x, eulerAngles.y, eulerAngles.z, 0),
				angle = angle,
				rotateMode = rotateMode
			});
			_tweenScales.Add(new TweenScale());

			_tweenPositionLifetimes.Add(new TweenLifetime());
			_tweenRotationLifetimes.Add(new TweenLifetime {
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_tweenScaleLifetimes.Add(new TweenLifetime());
		}
	}
}
