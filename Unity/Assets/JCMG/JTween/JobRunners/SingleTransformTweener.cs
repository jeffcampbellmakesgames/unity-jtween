using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Profiling;

namespace JCMG.JTween
{
	internal sealed class SingleTransformTweener : TransformTweenerBase
	{
		// Managed lists of tween data
		private readonly FastList<TweenHandle> _tweenHandles = new FastList<TweenHandle>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		public void Move(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			SpaceType spaceType,
			EaseType easeType,
			LoopType loopType,
			int loopCount,
			Action onStart,
			Action onComplete,
			bool useTweenHandle,
			out ITweenHandle tweenHandle)
		{
			tweenHandle = null;

			_transforms.Add(target);
			_transformAccessArray.Add(target);
			_tweenStates.Add(new TweenTransformState
			{
				state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
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
				loopCount = (short)loopCount,
				originalLoopCount = (short)loopCount
			});
			_tweenRotationLifetimes.Add(new TweenLifetime());
			_tweenScaleLifetimes.Add(new TweenLifetime());
			var hasEvents = onStart != null || onComplete != null;
			if (useTweenHandle || hasEvents)
			{
				var availableTweenHandle = GetNextAvailableTweenHandle();
				availableTweenHandle.state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START;
				if (onStart != null)
				{
					availableTweenHandle.AddOnStartedListener(onStart);
				}

				if (onComplete != null)
				{
					availableTweenHandle.AddOnCompetedListener(onComplete);
				}

				_tweenHandles.Add(availableTweenHandle);

				// Only populate the out parameter if explicitly called out for.
				if (useTweenHandle)
				{
					tweenHandle = availableTweenHandle;
				}
			}
			else
			{
				_tweenHandles.Add(null);
			}
		}

		public void Scale(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			EaseType easeType,
			LoopType loopType,
			int loopCount,
			Action onStart,
			Action onComplete,
			bool useTweenHandle,
			out ITweenHandle tweenHandle)
		{
			tweenHandle = null;

			_transforms.Add(target);
			_transformAccessArray.Add(target);
			_tweenStates.Add(new TweenTransformState
			{
				state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
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
				loopCount = (short)loopCount,
				originalLoopCount = (short)loopCount
			});
			var hasEvents = onStart != null || onComplete != null;
			if (useTweenHandle || hasEvents)
			{
				var availableTweenHandle = GetNextAvailableTweenHandle();
				availableTweenHandle.state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START;
				if (onStart != null)
				{
					availableTweenHandle.AddOnStartedListener(onStart);
				}

				if (onComplete != null)
				{
					availableTweenHandle.AddOnCompetedListener(onComplete);
				}

				_tweenHandles.Add(availableTweenHandle);

				// Only populate the out parameter if explicitly called out for.
				if (useTweenHandle)
				{
					tweenHandle = availableTweenHandle;
				}
			}
			else
			{
				_tweenHandles.Add(null);
			}
		}

		public void Rotate(
			Transform target,
			Quaternion from,
			Quaternion to,
			float duration,
			SpaceType spaceType,
			EaseType easeType,
			LoopType loopType,
			int loopCount,
			Action onStart,
			Action onComplete,
			bool useTweenHandle,
			out ITweenHandle tweenHandle)
		{
			tweenHandle = null;

			_transforms.Add(target);
			_transformAccessArray.Add(target);
			_tweenStates.Add(new TweenTransformState
			{
				state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
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
				loopCount = (short)loopCount,
				originalLoopCount = (short)loopCount
			});
			_tweenScaleLifetimes.Add(new TweenLifetime());
			var hasEvents = onStart != null || onComplete != null;
			if (useTweenHandle || hasEvents)
			{
				var availableTweenHandle = GetNextAvailableTweenHandle();
				availableTweenHandle.state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START;
				if (onStart != null)
				{
					availableTweenHandle.AddOnStartedListener(onStart);
				}

				if (onComplete != null)
				{
					availableTweenHandle.AddOnCompetedListener(onComplete);
				}

				_tweenHandles.Add(availableTweenHandle);

				// Only populate the out parameter if explicitly called out for.
				if (useTweenHandle)
				{
					tweenHandle = availableTweenHandle;
				}
			}
			else
			{
				_tweenHandles.Add(null);
			}
		}

		internal void RotateOnAxis(
			Transform target,
			float angle,
			float duration,
			RotateMode rotateMode,
			SpaceType spaceType,
			EaseType easeType,
			LoopType loopType,
			int loopCount,
			Action onStart,
			Action onComplete,
			bool useTweenHandle,
			out ITweenHandle tweenHandle)
		{
			tweenHandle = null;

			_transforms.Add(target);
			_transformAccessArray.Add(target);

			var rotateType = JTweenTools.GetTweenSpaceTypeFromRotateMode(rotateMode);
			_tweenStates.Add(new TweenTransformState
			{
				state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
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
				loopCount = (short)loopCount,
				originalLoopCount = (short)loopCount
			});
			_tweenScaleLifetimes.Add(new TweenLifetime());
			var hasEvents = onStart != null || onComplete != null;
			if (useTweenHandle || hasEvents)
			{
				var availableTweenHandle = GetNextAvailableTweenHandle();
				availableTweenHandle.state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START;
				if (onStart != null)
				{
					availableTweenHandle.AddOnStartedListener(onStart);
				}

				if (onComplete != null)
				{
					availableTweenHandle.AddOnCompetedListener(onComplete);
				}

				_tweenHandles.Add(availableTweenHandle);

				// Only populate the out parameter if explicitly called out for.
				if (useTweenHandle)
				{
					tweenHandle = availableTweenHandle;
				}
			}
			else
			{
				_tweenHandles.Add(null);
			}
		}

		internal override void QueueTweenHandleAction(TweenHandle tweenHandle)
		{
			var index = _tweenHandles.IndexOf(tweenHandle);
			if (index >= 0)
			{
				_tweenHandleActionEventQueue.Enqueue(new TweenHandleAction
				{
					actionType = tweenHandle.actionType,
					index = index
				});
			}
			else
			{
				Debug.LogWarning(RuntimeConstants.HANDLE_NOT_FOUND);
			}
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

			while (_tweenHandleActionEventQueue.Count > 0)
			{
				var tweenHandleAction = _tweenHandleActionEventQueue.Dequeue();
				if (tweenHandleAction.index >= 0 && tweenHandleAction.index < _tweenHandles.Length)
				{
					var tweenHandle = _tweenHandles.buffer[tweenHandleAction.index];
					var tweenState = _tweenStates.buffer[tweenHandleAction.index];
					switch (tweenHandleAction.actionType)
					{
						case TweenHandleActionType.Play:
							if (!tweenState.IsCompleted() && tweenState.IsPaused())
							{
								tweenState.state |= TweenStateType.IsPlaying;
								tweenState.state &= ~TweenStateType.IsPaused;
							}
							break;
						case TweenHandleActionType.Pause:
							if (tweenState.IsPlaying())
							{
								tweenState.state &= ~TweenStateType.IsPlaying;
								tweenState.state |= TweenStateType.IsPaused;
							}
							break;
						case TweenHandleActionType.Stop:
							if (tweenState.IsPlaying() || tweenState.IsPaused())
							{
								tweenState.state &= ~TweenStateType.IsPlaying;
								tweenState.state &= ~TweenStateType.IsPaused;
								tweenState.state |= TweenStateType.IsCompleted;
								tweenState.state |= TweenStateType.JustEnded;
							}
							break;
						case TweenHandleActionType.Recycle:
							tweenState.state &= ~TweenStateType.IsPaused;
							tweenState.state &= ~TweenStateType.IsPlaying;
							tweenState.state &= ~TweenStateType.HasHandle;
							tweenState.state |= TweenStateType.IsCompleted;
							tweenState.state |= TweenStateType.RequiresRecycling;
							break;
						case TweenHandleActionType.Rewind:
							tweenState.state = HANDLE_START_PAUSED;
							RewindTransformLifetimes(tweenHandleAction.index);
							break;
						case TweenHandleActionType.Restart:
							tweenState.state = HANDLE_START_PLAYING;
							RewindTransformLifetimes(tweenHandleAction.index);
							break;
						case TweenHandleActionType.None:
						default:
							throw new NotImplementedException();
					}

					tweenHandle.state = tweenState.state;

					_tweenStates.buffer[tweenHandleAction.index] = tweenState;
				}
				else
				{
					Debug.LogWarning(RuntimeConstants.HANDLE_NOT_FOUND);
				}
			}

			// Capture all Started events that need to take place and add them to the event queue.
			for (var i = 0; i < _tweenStates.Length; i++)
			{
				var tweenState = _tweenStates.buffer[i];
				if (tweenState.IsPlaying() && tweenState.JustStarted())
				{
					tweenState.state &= ~TweenStateType.JustStarted;
					_tweenStates.buffer[i] = tweenState;

					if (_tweenHandles.buffer[i] != null)
					{
						_tweenHandles.buffer[i].state = tweenState.state;
						_tweenHandleCallbackEventQueue.Enqueue(_tweenHandles.buffer[i]);
					}
				}
			}

			CreateNativeTransformCollections();

			SetupJobs();

			_isJobScheduled = true;

			Profiler.EndSample();

			Profiler.BeginSample(EVENT_STARTED_PROFILE);

			// After all sensitive native work has completed, kick out any and all started events
			for (var i = _tweenHandleCallbackEventQueue.Count - 1; i >= 0; i--)
			{
				// Pop the latest element so that if a downstream error occurs we do not repeat it
				// endlessly and block the queue.
				var tweenEvent = _tweenHandleCallbackEventQueue.Dequeue();

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

				if (_tweenHandles.buffer[i] != null)
				{
					_tweenHandles.buffer[i].state = tweenState.state;
				}

				if (tweenState.IsCompleted())
				{
					if (tweenState.JustEnded())
					{
						tweenState.state &= ~TweenStateType.JustEnded;
						_tweenStates.buffer[i] = tweenState;

						if (_tweenHandles.buffer[i] != null)
						{
							_tweenHandles.buffer[i].state = tweenState.state;
							_tweenHandleCallbackEventQueue.Enqueue(_tweenHandles.buffer[i]);
						}
					}

					if (tweenState.RequiresRecycling())
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
						_tweenHandles.RemoveAt(i);
						Profiler.EndSample();
					}
				}
			}

			// Properly dispose of the native collections
			DisposeNativeTransformCollections();

			Profiler.EndSample();

			Profiler.BeginSample(EVENT_COMPLETED_PROFILE);

			// After all sensitive native work has completed, kick out any and all completed events
			for (var i = _tweenHandleCallbackEventQueue.Count - 1; i >= 0; i--)
			{
				// Pop the latest element so that if a downstream error occurs we do not repeat it
				// endlessly and block the queue.
				var tweenHandle = _tweenHandleCallbackEventQueue.Dequeue();
				_tweenHandlePool.Add(tweenHandle);

				tweenHandle.Completed?.Invoke();
			}

			Profiler.EndSample();
		}

		private void RewindTransformLifetimes(int index)
		{
			var tweenPosLifetime = _tweenPositionLifetimes.buffer[index];
			tweenPosLifetime.Restart();
			_tweenPositionLifetimes.buffer[index] = tweenPosLifetime;

			var tweenRotLifetime = _tweenRotationLifetimes.buffer[index];
			tweenRotLifetime.Restart();
			_tweenRotationLifetimes.buffer[index] = tweenRotLifetime;

			var tweenScaleLifetime = _tweenScaleLifetimes.buffer[index];
			tweenScaleLifetime.Restart();
			_tweenScaleLifetimes.buffer[index] = tweenScaleLifetime;
		}
	}
}
