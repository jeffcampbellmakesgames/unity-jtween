using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Profiling;

namespace JCMG.JTween
{
	internal sealed class SingleTransformTweener : TransformTweenerBase
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

			_tweenPositions.Add(new TweenFloat3 { from = from, to = to });
			_tweenRotations.Add(new TweenRotation());
			_tweenScales.Add(new TweenFloat3());

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

			_tweenStates.Add(new TweenTransformState { isPlaying = TRUE, isScalingEnabled = TRUE });

			_tweenPositions.Add(new TweenFloat3());
			_tweenRotations.Add(new TweenRotation());
			_tweenScales.Add(new TweenFloat3 { from = from, to = to });

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

			_tweenPositions.Add(new TweenFloat3());
			_tweenRotations.Add(new TweenRotation
			{
				from = from,
				to = to,
				rotateMode = RotateMode.XYZ
			});
			_tweenScales.Add(new TweenFloat3());

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

			_tweenPositions.Add(new TweenFloat3());

			var eulerAngles = spaceType == SpaceType.World
				? target.eulerAngles
				: target.localEulerAngles;

			_tweenRotations.Add(new TweenRotation
			{
				from = new quaternion(eulerAngles.x, eulerAngles.y, eulerAngles.z, 0),
				angle = angle,
				rotateMode = rotateMode
			});
			_tweenScales.Add(new TweenFloat3());

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

		protected override void UpdateTweens()
		{
			Profiler.BeginSample(UPDATE_PROFILE);

			// If we do not have any tweens to handle, return early.
			if (_transforms.Length == 0)
			{
				Profiler.EndSample();
				return;
			}

			CreateNativeTransformCollections();

			SetupJobs();

			_isJobScheduled = true;

			Profiler.EndSample();
		}

		protected override void LateUpdateTweens()
		{
			Profiler.BeginSample(LATE_UPDATE_PROFILE);

			// If a job was never scheduled, return.
			if (!_isJobScheduled)
			{
				Profiler.EndSample();
				return;
			}

			_isJobScheduled = false;

			// Complete the job and any dependencies.
			applyTweenUpdates.Complete();

			// Get the data we need back from the native collections or if tween completed remove it.
			CopyNativeCollectionsToManaged();

			for (var i = _nativeTweenStates.Length - 1; i >= 0; i--)
			{
				var tweenState = _tweenStates.buffer[i];
				if (tweenState.isPlaying == FALSE)
				{
					Profiler.BeginSample(TRANSFORM_ACCESS_ARRAY_REMOVE_PROFILE);
					_transformAccessArray.RemoveAtSwapBack(i);
					Profiler.EndSample();

					Profiler.BeginSample(FAST_LIST_REMOVE_AT);
					_transforms.RemoveAt(i);
					_tweenStates.RemoveAt(i);
					_tweenPositions.RemoveAt(i);
					_tweenRotations.RemoveAt(i);
					_tweenScales.RemoveAt(i);
					_tweenPositionLifetimes.RemoveAt(i);
					_tweenRotationLifetimes.RemoveAt(i);
					_tweenScaleLifetimes.RemoveAt(i);
					Profiler.EndSample();
				}
			}

			// Properly dispose of the native collections
			DisposeNativeTransformCollections();

			Profiler.EndSample();
		}
	}
}
