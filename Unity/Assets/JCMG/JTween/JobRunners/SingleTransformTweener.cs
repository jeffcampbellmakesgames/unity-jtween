using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Profiling;

namespace JCMG.JTween
{
	internal sealed class SingleTransformTweener : TransformTweenerBase
	{
		private readonly FastList<TweenEvent> _tweenEvents = new FastList<TweenEvent>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		public void Move(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_transforms.Add(target);
			_transformAccessArray.Add(target);

			_tweenStates.Add(new TweenTransformState
			{
				state = TweenStateType.IsPlaying | TweenStateType.JustStarted,
				transformType = TweenTransformType.Movement,
				spaceType = spaceType == SpaceType.World
					? TweenSpaceType.WorldMovement
					: TweenSpaceType.LocalMovement
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

			_tweenEvents.Add(new TweenEvent{Completed = onComplete, Started = onStart});
		}

		public void Scale(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_transforms.Add(target);
			_transformAccessArray.Add(target);

			_tweenStates.Add(new TweenTransformState
			{
				state = TweenStateType.IsPlaying | TweenStateType.JustStarted,
				transformType = TweenTransformType.Scaling
			});

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

			_tweenEvents.Add(new TweenEvent { Completed = onComplete, Started = onStart });
		}

		public void Rotate(
			Transform target,
			Quaternion from,
			Quaternion to,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_transforms.Add(target);
			_transformAccessArray.Add(target);

			_tweenStates.Add(new TweenTransformState
			{
				state = TweenStateType.IsPlaying | TweenStateType.JustStarted,
				transformType = TweenTransformType.Rotation,
				spaceType = spaceType == SpaceType.World
					? TweenSpaceType.WorldRotation | TweenSpaceType.RotateModeXYZ
					: TweenSpaceType.LocalRotation | TweenSpaceType.RotateModeXYZ
			});

			_tweenPositions.Add(new TweenFloat3());
			_tweenRotations.Add(new TweenRotation
			{
				from = from,
				to = to
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

			_tweenEvents.Add(new TweenEvent { Completed = onComplete, Started = onStart });
		}

		internal void RotateOnAxis(
			Transform target,
			float angle,
			float duration,
			SpaceType spaceType,
			EaseType easeType,
			LoopType loopType,
			int loopCount,
			RotateMode rotateMode,
			Action onStart = null,
			Action onComplete = null)
		{
			_transforms.Add(target);
			_transformAccessArray.Add(target);

			var rotateType = JTweenTools.GetTweenSpaceTypeFromRotateMode(rotateMode);
			_tweenStates.Add(new TweenTransformState
			{
				state = TweenStateType.IsPlaying | TweenStateType.JustStarted,
				transformType = TweenTransformType.Rotation,
				spaceType = spaceType == SpaceType.World
					? TweenSpaceType.WorldRotation | rotateType
					: TweenSpaceType.LocalRotation | rotateType
			});

			_tweenPositions.Add(new TweenFloat3());

			var eulerAngles = spaceType == SpaceType.World
				? target.eulerAngles
				: target.localEulerAngles;

			_tweenRotations.Add(new TweenRotation
			{
				from = new quaternion(eulerAngles.x, eulerAngles.y, eulerAngles.z, 0),
				angle = angle
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

			_tweenEvents.Add(new TweenEvent { Completed = onComplete, Started = onStart });
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

			// Capture all Started events that need to take place and add them to the event queue.
			for (var i = 0; i < _tweenStates.Length; i++)
			{
				var tweenState = _tweenStates.buffer[i];
				if ((tweenState.state & TweenStateType.JustStarted) == TweenStateType.JustStarted)
				{
					tweenState.state &= ~TweenStateType.JustStarted;
					_tweenStates.buffer[i] = tweenState;
					_eventQueue.Add(_tweenEvents.buffer[i]);
				}
			}

			CreateNativeTransformCollections();

			SetupJobs();

			_isJobScheduled = true;

			Profiler.EndSample();

			Profiler.BeginSample(EVENT_STARTED_PROFILE);

			// After all sensitive native work has completed, kick out any and all started events
			for (var i = _eventQueue.Length - 1; i >= 0; i--)
			{
				// Pop the latest element so that if a downstream error occurs we do not repeat it
				// endlessly and block the queue.
				var tweenEvent = _eventQueue.PopLast();

				tweenEvent.Started?.Invoke();
			}

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

			for (var i = _tweenStates.Length - 1; i >= 0; i--)
			{
				var tweenState = _tweenStates.buffer[i];
				if (tweenState.IsCompleted())
				{
					Profiler.BeginSample(TRANSFORM_ACCESS_ARRAY_REMOVE_PROFILE);
					_transformAccessArray.RemoveAtSwapBack(i);
					Profiler.EndSample();

					_eventQueue.Add(_tweenEvents.buffer[i]);

					Profiler.BeginSample(FAST_LIST_REMOVE_AT);
					_transforms.RemoveAt(i);
					_tweenStates.RemoveAt(i);
					_tweenPositions.RemoveAt(i);
					_tweenRotations.RemoveAt(i);
					_tweenScales.RemoveAt(i);
					_tweenPositionLifetimes.RemoveAt(i);
					_tweenRotationLifetimes.RemoveAt(i);
					_tweenScaleLifetimes.RemoveAt(i);
					_tweenEvents.RemoveAt(i);
					Profiler.EndSample();
				}
			}

			// Properly dispose of the native collections
			DisposeNativeTransformCollections();

			Profiler.EndSample();

			Profiler.BeginSample(EVENT_COMPLETED_PROFILE);

			// After all sensitive native work has completed, kick out any and all completed events
			for (var i = _eventQueue.Length - 1; i >= 0; i--)
			{
				// Pop the latest element so that if a downstream error occurs we do not repeat it
				// endlessly and block the queue.
				var tweenEvent = _eventQueue.PopLast();

				tweenEvent.Completed?.Invoke();
			}

			Profiler.EndSample();
		}
	}
}
