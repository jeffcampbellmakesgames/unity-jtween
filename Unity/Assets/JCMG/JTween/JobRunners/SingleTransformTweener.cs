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

			_tweenPositions.Add(new TweenPosition { from = from, to = to });
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

			_tweenStates.Add(new TweenTransformState { isPlaying = TRUE, isScalingEnabled = TRUE });

			_tweenPositions.Add(new TweenPosition());
			_tweenRotations.Add(new TweenRotation());
			_tweenScales.Add(new TweenScale { from = from, to = to });

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
				from = from,
				to = to,
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

			_tweenRotations.Add(new TweenRotation
			{
				from = new quaternion(eulerAngles.x, eulerAngles.y, eulerAngles.z, 0),
				angle = angle,
				rotateMode = rotateMode
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

		internal override void UpdateTweens()
		{
			Profiler.BeginSample(UPDATE_PROFILE);

			// If we do not have any tweens to handle, return early.
			if (_transforms.Length == 0)
			{
				Profiler.EndSample();
				return;
			}

			// Create and setup native collections. Copy over existing data
			_nativeTweenStates = new NativeArray<TweenTransformState>(_tweenStates.Length, Allocator.TempJob);
			JTweenTools.CopyTweenStateDirectlyToNativeArray(_tweenStates.buffer, _nativeTweenStates, _tweenStates.Length);

			_nativeTweenPositions = new NativeArray<TweenPosition>(_tweenPositions.Length, Allocator.TempJob);
			JTweenTools.CopyTweenPositionDirectlyToNativeArray(_tweenPositions.buffer, _nativeTweenPositions, _tweenPositions.Length);

			_nativeTweenRotations = new NativeArray<TweenRotation>(_tweenRotations.Length, Allocator.TempJob);
			JTweenTools.CopyTweenRotationDirectlyToNativeArray(_tweenRotations.buffer, _nativeTweenRotations, _tweenRotations.Length);

			_nativeTweenScales = new NativeArray<TweenScale>(_tweenScales.Length, Allocator.TempJob);
			JTweenTools.CopyTweenScaleDirectlyToNativeArray(_tweenScales.buffer, _nativeTweenScales, _tweenScales.Length);

			_nativePositionLifetimes = new NativeArray<TweenLifetime>(_tweenPositionLifetimes.Length, Allocator.TempJob);
			JTweenTools.CopyTweenLifetimeDirectlyToNativeArray(_tweenPositionLifetimes.buffer, _nativePositionLifetimes, _tweenPositionLifetimes.Length);

			_nativeRotationLifetimes = new NativeArray<TweenLifetime>(_tweenRotationLifetimes.Length, Allocator.TempJob);
			JTweenTools.CopyTweenLifetimeDirectlyToNativeArray(_tweenRotationLifetimes.buffer, _nativeRotationLifetimes, _tweenRotationLifetimes.Length);

			_nativeScaleLifetimes = new NativeArray<TweenLifetime>(_tweenScaleLifetimes.Length, Allocator.TempJob);
			JTweenTools.CopyTweenLifetimeDirectlyToNativeArray(_tweenScaleLifetimes.buffer, _nativeScaleLifetimes, _tweenScaleLifetimes.Length);

			_nativePositions = new NativeArray<float3>(_tweenPositions.Length, Allocator.TempJob);
			_nativeRotations = new NativeArray<quaternion>(_tweenRotations.Length, Allocator.TempJob);
			_nativeScales = new NativeArray<float3>(_tweenScales.Length, Allocator.TempJob);

			// Create and schedule Jobs
			_processTweenJob = new ProcessTweenJob
			{
				deltaTime = _deltaTime,
				tweenStates = _nativeTweenStates,
				tweenPositions = _nativeTweenPositions,
				tweenRotations = _nativeTweenRotations,
				tweenScales = _nativeTweenScales,
				positions = _nativePositions,
				rotations = _nativeRotations,
				scales = _nativeScales,
				tweenPositionLifetimes = _nativePositionLifetimes,
				tweenRotationLifetimes = _nativeRotationLifetimes,
				tweenScaleLifetimes = _nativeScaleLifetimes
			};

			// Break this up into larger batches, the work is fairly inexpensive.
			_processTweenJobHandle = _processTweenJob.Schedule(_nativeTweenStates.Length, 128);

			_applyTweenToTransformJob = new ApplyTweenToTransformJob
			{
				tweenStates = _nativeTweenStates,
				positions = _nativePositions,
				rotations = _nativeRotations,
				scales = _nativeScales
			};

			applyTweenUpdates = _applyTweenToTransformJob.Schedule(_transformAccessArray, _processTweenJobHandle);

			_isJobScheduled = true;

			Profiler.EndSample();
		}

		internal override void LateUpdateTweens()
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
			JTweenTools.CopyNativeArrayDirectlyToTweenState(_nativeTweenStates, _tweenStates.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativePositionLifetimes, _tweenPositionLifetimes.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativeRotationLifetimes, _tweenRotationLifetimes.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativeScaleLifetimes, _tweenScaleLifetimes.buffer);

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
			_nativeTweenStates.Dispose();
			_nativeTweenPositions.Dispose();
			_nativeTweenRotations.Dispose();
			_nativeTweenScales.Dispose();
			_nativePositionLifetimes.Dispose();
			_nativeRotationLifetimes.Dispose();
			_nativeScaleLifetimes.Dispose();
			_nativePositions.Dispose();
			_nativeRotations.Dispose();
			_nativeScales.Dispose();

			Profiler.EndSample();
		}
	}
}
