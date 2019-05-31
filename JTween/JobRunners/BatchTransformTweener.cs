using System;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Profiling;

namespace JCMG.JTween
{
	internal sealed class BatchTransformTweener : TransformTweenerBase
	{
		// Managed lists of tween data for batching
		private readonly FastList<TweenTransformBatchState> _tweenBatches = new FastList<TweenTransformBatchState>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenLifetime> _tweenBatchLifetimes = new FastList<TweenLifetime>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenHandle> _tweenBatchHandles = new FastList<TweenHandle>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		// Native collections for batching.
		private NativeArray<TweenTransformBatchState> _nativeTweenBatches;
		private NativeArray<TweenLifetime> _nativeTweenBatchLifetimes;

		// Job Handles
		private JobHandle _processBatchJobHandle;

		// Jobs
		private ProcessBatchJob _processBatchJob;

		public void BatchMove(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
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
			// Ensure that our arrays are non-null and have sufficient capacity for the intended slice.
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length >= startIndex + length &&
						  fromArray.Length >= startIndex + length &&
						  fromArray.Length >= startIndex + length);

			tweenHandle = null;

			var batchIndex = _transforms.Length;
			var batchLength = length;
			_tweenBatches.Add(new TweenTransformBatchState
			{
				state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
				startIndex = (uint)batchIndex,
				length = (uint)batchLength
			});
			_tweenBatchLifetimes.Add(new TweenLifetime
			{
				duration = Mathf.Max(0, duration),
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue),
				originalLoopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue)
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
					availableTweenHandle.AddOnCompletedListener(onComplete);
				}

				_tweenBatchHandles.Add(availableTweenHandle);

				// Only populate the out parameter if explicitly called out for.
				if (useTweenHandle)
				{
					tweenHandle = availableTweenHandle;
				}
			}
			else
			{
				_tweenBatchHandles.Add(null);
			}

			_transforms.AddRange(targets, startIndex, length);
			for (var i = 0; i < batchLength; i++)
			{
				var normalizedIndex = startIndex + i;
				var normalizedBatchIndex = batchIndex + i;
				_transformAccessArray.Add(_transforms.buffer[normalizedBatchIndex]);
				_tweenStates.Add(new TweenTransformState
				{
					state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
					transformType = TweenTransformType.Movement,
					spaceType = spaceType == SpaceType.World
						? TweenSpaceType.WorldMovement
						: TweenSpaceType.LocalMovement
				});
				_tweenPositions.Add(new TweenFloat3 { from = fromArray[normalizedIndex], to = toArray[normalizedIndex] });
				_tweenRotations.Add(new TweenRotation());
				_tweenScales.Add(new TweenFloat3());
				_tweenPositionLifetimes.Add(new TweenLifetime
				{
					duration = Mathf.Max(0, duration),
					easeType = easeType,
					loopType = loopType,
					loopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue),
					originalLoopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue)
				});
				_tweenRotationLifetimes.Add(new TweenLifetime());
				_tweenScaleLifetimes.Add(new TweenLifetime());
			}
		}

		public void BatchScale(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
			float duration,
			EaseType easeType,
			LoopType loopType,
			int loopCount,
			Action onStart,
			Action onComplete,
			bool useTweenHandle,
			out ITweenHandle tweenHandle)
		{
			// Ensure that our arrays are non-null and have sufficient capacity for the intended slice.
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length >= startIndex + length &&
			              fromArray.Length >= startIndex + length &&
			              fromArray.Length >= startIndex + length);

			tweenHandle = null;

			var batchIndex = _transforms.Length;
			var batchLength = length;
			_tweenBatches.Add(new TweenTransformBatchState
			{
				state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
				startIndex = (uint)batchIndex,
				length = (uint)batchLength
			});
			_tweenBatchLifetimes.Add(new TweenLifetime
			{
				duration = Mathf.Max(0, duration),
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue),
				originalLoopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue)
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
					availableTweenHandle.AddOnCompletedListener(onComplete);
				}

				_tweenBatchHandles.Add(availableTweenHandle);

				// Only populate the out parameter if explicitly called out for.
				if (useTweenHandle)
				{
					tweenHandle = availableTweenHandle;
				}
			}
			else
			{
				_tweenBatchHandles.Add(null);
			}

			_transforms.AddRange(targets, startIndex, length);
			for (var i = 0; i < batchLength; i++)
			{
				var normalizedIndex = startIndex + i;
				var normalizedBatchIndex = batchIndex + i;
				_transformAccessArray.Add(_transforms.buffer[normalizedBatchIndex]);
				_tweenStates.Add(new TweenTransformState
				{
					state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
					transformType = TweenTransformType.Scaling
				});
				_tweenPositions.Add(new TweenFloat3());
				_tweenRotations.Add(new TweenRotation());
				_tweenScales.Add(new TweenFloat3 { from = fromArray[normalizedIndex], to = toArray[normalizedIndex] });
				_tweenPositionLifetimes.Add(new TweenLifetime());
				_tweenRotationLifetimes.Add(new TweenLifetime());
				_tweenScaleLifetimes.Add(new TweenLifetime
				{
					duration = Mathf.Max(0, duration),
					easeType = easeType,
					loopType = loopType,
					loopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue),
					originalLoopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue)
				});
			}
		}

		public void BatchRotate(
			Transform[] targets,
			Quaternion[] fromArray,
			Quaternion[] toArray,
			int startIndex,
			int length,
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
			// Ensure that our arrays are non-null and have sufficient capacity for the intended slice.
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length >= startIndex + length &&
						  fromArray.Length >= startIndex + length &&
						  fromArray.Length >= startIndex + length);

			tweenHandle = null;

			var batchIndex = _transforms.Length;
			var batchLength = length;
			_tweenBatches.Add(new TweenTransformBatchState
			{
				state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
				startIndex = (uint)batchIndex,
				length = (uint)batchLength
			});
			_tweenBatchLifetimes.Add(new TweenLifetime
			{
				duration = Mathf.Max(0, duration),
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue),
				originalLoopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue)
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
					availableTweenHandle.AddOnCompletedListener(onComplete);
				}

				_tweenBatchHandles.Add(availableTweenHandle);

				// Only populate the out parameter if explicitly called out for.
				if (useTweenHandle)
				{
					tweenHandle = availableTweenHandle;
				}
			}
			else
			{
				_tweenBatchHandles.Add(null);
			}

			_transforms.AddRange(targets, startIndex, length);
			for (var i = 0; i < batchLength; i++)
			{
				var normalizedIndex = startIndex + i;
				var normalizedBatchIndex = batchIndex + i;
				_transformAccessArray.Add(_transforms.buffer[normalizedBatchIndex]);
				_tweenStates.Add(new TweenTransformState
				{
					state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
					transformType = TweenTransformType.Rotation,
					spaceType = spaceType == SpaceType.World
						? TweenSpaceType.WorldRotation
						: TweenSpaceType.LocalRotation
				});
				_tweenPositions.Add(new TweenFloat3());
				_tweenRotations.Add(new TweenRotation { from = fromArray[normalizedIndex], to = toArray[normalizedIndex] });
				_tweenScales.Add(new TweenFloat3());
				_tweenPositionLifetimes.Add(new TweenLifetime());
				_tweenRotationLifetimes.Add(new TweenLifetime
				{
					duration = Mathf.Max(0, duration),
					easeType = easeType,
					loopType = loopType,
					loopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue),
					originalLoopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue)
				});
				_tweenScaleLifetimes.Add(new TweenLifetime());
			}
		}

		public void BatchUpdateTransforms(
			Transform[] targets,
			Vector3[] fromPosArray,
			Vector3[] toPosArray,
			Quaternion[] fromRotArray,
			Quaternion[] toRotArray,
			Vector3[] fromScaleArray,
			Vector3[] toScaleArray,
			int startIndex,
			int length,
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
			// Ensure that our arrays are non-null and have sufficient capacity for the intended slice.
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromRotArray);
			Assert.IsNotNull(toRotArray);
			Assert.IsTrue(targets.Length >= startIndex + length &&
			              fromPosArray.Length >= startIndex + length &&
			              toPosArray.Length >= startIndex + length &&
			              fromRotArray.Length >= startIndex + length &&
			              toRotArray.Length >= startIndex + length &&
			              fromScaleArray.Length >= startIndex + length &&
			              toScaleArray.Length >= startIndex + length);

			tweenHandle = null;

			var batchIndex = _transforms.Length;
			var batchLength = length;
			_tweenBatches.Add(new TweenTransformBatchState
			{
				state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
				startIndex = (uint)batchIndex,
				length = (uint)batchLength
			});
			_tweenBatchLifetimes.Add(new TweenLifetime
			{
				duration = Mathf.Max(0, duration),
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue),
				originalLoopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue)
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
					availableTweenHandle.AddOnCompletedListener(onComplete);
				}

				_tweenBatchHandles.Add(availableTweenHandle);

				// Only populate the out parameter if explicitly called out for.
				if (useTweenHandle)
				{
					tweenHandle = availableTweenHandle;
				}
			}
			else
			{
				_tweenBatchHandles.Add(null);
			}

			_transforms.AddRange(targets, startIndex, length);
			for (var i = 0; i < batchLength; i++)
			{
				var normalizedIndex = startIndex + i;
				var normalizedBatchIndex = batchIndex + i;
				_transformAccessArray.Add(_transforms.buffer[normalizedBatchIndex]);
				_tweenStates.Add(new TweenTransformState
				{
					state = useTweenHandle ? HANDLE_START_PAUSED : NO_HANDLE_START,
					transformType = TweenTransformType.Movement |
					                TweenTransformType.Rotation |
					                TweenTransformType.Scaling,
					spaceType = spaceType == SpaceType.World
						? TweenSpaceType.WorldMovement | TweenSpaceType.WorldRotation
						: TweenSpaceType.LocalMovement | TweenSpaceType.LocalRotation
				});
				_tweenPositions.Add(new TweenFloat3 { from = fromPosArray[normalizedIndex], to = toPosArray[normalizedIndex] });
				_tweenRotations.Add(new TweenRotation { from = fromRotArray[normalizedIndex], to = toRotArray[normalizedIndex] });
				_tweenScales.Add(new TweenFloat3 { from = fromScaleArray[normalizedIndex], to = toScaleArray[normalizedIndex] });

				var lifetime = new TweenLifetime
				{
					duration = Mathf.Max(0, duration),
					easeType = easeType,
					loopType = loopType,
					loopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue),
					originalLoopCount = (short)Mathf.Clamp(loopCount, -1, short.MaxValue)
				};
				_tweenPositionLifetimes.Add(lifetime);
				_tweenRotationLifetimes.Add(lifetime);
				_tweenScaleLifetimes.Add(lifetime);
			}
		}

		internal override void QueueTweenHandleAction(TweenHandle tweenHandle)
		{
			var index = _tweenBatchHandles.IndexOf(tweenHandle);
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
				Debug.LogWarning(RuntimeConstants.HANDLE_BATCH_NOT_FOUND);
			}
		}

		protected override void Teardown()
		{
			base.Teardown();

			if (_nativeTweenBatches.IsCreated)
			{
				_nativeTweenBatches.Dispose();
			}

			if (_nativeTweenBatchLifetimes.IsCreated)
			{
				_nativeTweenBatchLifetimes.Dispose();
			}
		}

		protected override void UpdateTweens()
		{
			Profiler.BeginSample(UPDATE_PROFILE);
			if (_transforms.Length == 0)
			{
				Profiler.EndSample();
				return;
			}

			while (_tweenHandleActionEventQueue.Count > 0)
			{
				var updateLifetimes = false;
				var tweenHandleAction = _tweenHandleActionEventQueue.Dequeue();
				if (tweenHandleAction.index >= 0 && tweenHandleAction.index < _tweenBatchHandles.Length)
				{
					var tweenHandle = _tweenBatchHandles.buffer[tweenHandleAction.index];
					var tweenBatch = _tweenBatches.buffer[tweenHandleAction.index];
					switch (tweenHandle.actionType)
					{
						case TweenHandleActionType.Play:
							if (!tweenBatch.IsCompleted() && tweenBatch.IsPaused())
							{
								tweenBatch.state |= TweenStateType.IsPlaying;
								tweenBatch.state &= ~TweenStateType.IsPaused;
							}
							break;
						case TweenHandleActionType.Pause:
							if (tweenBatch.IsPlaying())
							{
								tweenBatch.state &= ~TweenStateType.IsPlaying;
								tweenBatch.state |= TweenStateType.IsPaused;
							}
							break;
						case TweenHandleActionType.Stop:
							if (tweenBatch.IsPlaying() || tweenBatch.IsPaused())
							{
								tweenBatch.state &= ~TweenStateType.IsPlaying;
								tweenBatch.state &= ~TweenStateType.IsPaused;
								tweenBatch.state |= TweenStateType.IsCompleted;
								tweenBatch.state |= TweenStateType.JustEnded;
							}
							break;
						case TweenHandleActionType.Recycle:
							tweenBatch.state &= ~TweenStateType.IsPaused;
							tweenBatch.state &= ~TweenStateType.IsPlaying;
							tweenBatch.state &= ~TweenStateType.HasHandle;
							tweenBatch.state |= TweenStateType.IsCompleted;
							tweenBatch.state |= TweenStateType.RequiresRecycling;
							break;
						case TweenHandleActionType.Rewind:
							tweenBatch.state = HANDLE_START_PAUSED;
							var tweenBatchLifetimeRewind = _tweenBatchLifetimes.buffer[tweenHandleAction.index];
							tweenBatchLifetimeRewind.Restart();
							_tweenBatchLifetimes.buffer[tweenHandleAction.index] = tweenBatchLifetimeRewind;

							updateLifetimes = true;
							break;
						case TweenHandleActionType.Restart:
							tweenBatch.state = HANDLE_START_PLAYING;
							var tweenBatchLifetimeRestart = _tweenBatchLifetimes.buffer[tweenHandleAction.index];
							tweenBatchLifetimeRestart.Restart();
							_tweenBatchLifetimes.buffer[tweenHandleAction.index] = tweenBatchLifetimeRestart;

							updateLifetimes = true;

							break;
						case TweenHandleActionType.None:
						default:
							throw new NotImplementedException();
					}

					for (var i = tweenBatch.startIndex; i < tweenBatch.startIndex + tweenBatch.length; i++)
					{
						var tweenState = _tweenStates.buffer[i];
						tweenState.state = tweenBatch.state;
						_tweenStates.buffer[i] = tweenState;

						if (updateLifetimes)
						{
							var tweenPosLifetime = _tweenPositionLifetimes.buffer[i];
							tweenPosLifetime.Restart();
							_tweenPositionLifetimes.buffer[i] = tweenPosLifetime;

							var tweenRotLifetime = _tweenRotationLifetimes.buffer[i];
							tweenRotLifetime.Restart();
							_tweenRotationLifetimes.buffer[i] = tweenRotLifetime;

							var tweenScaleLifetime = _tweenScaleLifetimes.buffer[i];
							tweenScaleLifetime.Restart();
							_tweenScaleLifetimes.buffer[i] = tweenScaleLifetime;
						}
					}

					tweenHandle.state = tweenBatch.state;

					_tweenBatches.buffer[tweenHandleAction.index] = tweenBatch;
				}
				else
				{
					Debug.LogWarning(RuntimeConstants.HANDLE_BATCH_NOT_FOUND);
				}
			}

			for (var i = 0; i < _tweenBatches.Length; i++)
			{
				var tweenBatch = _tweenBatches.buffer[i];
				if (tweenBatch.IsPlaying() && tweenBatch.JustStarted())
				{
					tweenBatch.state &= ~TweenStateType.JustStarted;

					_tweenBatches.buffer[i] = tweenBatch;

					if (_tweenBatchHandles.buffer[i] != null)
					{
						_tweenBatchHandles.buffer[i].state = tweenBatch.state;
						_tweenHandleCallbackEventQueue.Enqueue(_tweenBatchHandles.buffer[i]);
					}
				}
			}

			// Create and setup native collections. Copy over existing data
			CreateNativeTransformCollections();

			_nativeTweenBatches = new NativeArray<TweenTransformBatchState>(_tweenBatches.Length, Allocator.TempJob);
			JTweenTools.CopyTweenBatchDirectlyToNativeArray(_tweenBatches.buffer, _nativeTweenBatches, _tweenBatches.Length);

			_nativeTweenBatchLifetimes = new NativeArray<TweenLifetime>(_tweenBatchLifetimes.Length, Allocator.TempJob);
			JTweenTools.CopyTweenLifetimeDirectlyToNativeArray(_tweenBatchLifetimes.buffer, _nativeTweenBatchLifetimes, _tweenBatchLifetimes.Length);

			// Schedule Jobs
			_processBatchJob = new ProcessBatchJob
			{
				deltaTime = _deltaTime,
				batchLifetimes = _nativeTweenBatchLifetimes,
				tweenBatches = _nativeTweenBatches
			};

			_processBatchJobHandle = _processBatchJob.Schedule(_tweenBatches.Length, 1);

			SetupJobs();

			_isJobScheduled = true;

			Profiler.EndSample();

			Profiler.BeginSample(EVENT_STARTED_PROFILE);

			// After all sensitive native work has completed, kick out any and all started events
			while(_tweenHandleCallbackEventQueue.Count > 0)
			{
				var tweenEvent = _tweenHandleCallbackEventQueue.Dequeue();
				tweenEvent.Started?.Invoke();
			}

			Profiler.EndSample();
		}

		protected override void LateUpdateTweens()
		{
			Profiler.BeginSample(LATE_UPDATE_PROFILE);
			if (!_isJobScheduled)
			{
				Profiler.EndSample();
				return;
			}

			_isJobScheduled = false;

			// Complete the batch process job
			_processBatchJobHandle.Complete();

			JTweenTools.CopyNativeArrayDirectlyToTweenBatch(_nativeTweenBatches, _tweenBatches.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativeTweenBatchLifetimes, _tweenBatchLifetimes.buffer);

			// Complete the tween job and any dependencies
			applyTweenUpdates.Complete();

			// Get the data we need back from the native collections or if tween completed remove it.
			CopyNativeCollectionsToManaged();

			// Sort batches from earliest index to latest, check for any completed batches,
			// and then remove en masse tweens where their batch is complete.
			for (var i = _tweenBatches.Length - 1; i >= 0; i--)
			{
				var batch = _tweenBatches.buffer[i];

				if (_tweenBatchHandles.buffer[i] != null)
				{
					_tweenBatchHandles.buffer[i].state = batch.state;
				}

				if (batch.IsCompleted())
				{
					if (batch.JustEnded())
					{
						batch.state &= ~TweenStateType.JustEnded;
						_tweenBatches.buffer[i] = batch;

						if (_tweenBatchHandles.buffer[i] != null)
						{
							_tweenBatchHandles.buffer[i].state = batch.state;
							_tweenHandleCallbackEventQueue.Enqueue(_tweenBatchHandles.buffer[i]);
						}
					}

					if (batch.RequiresRecycling())
					{
						var index = (int)batch.startIndex;
						var length = (int)batch.length;

						// We don't have a great option here for removing a range of transforms from this
						// specific native collection type.
						for (var j = index + length - 1; j >= index; j--)
						{
							Profiler.BeginSample(TRANSFORM_ACCESS_ARRAY_REMOVE_PROFILE);
							_transformAccessArray.RemoveAtSwapBack(j);
							Profiler.EndSample();
						}

						Profiler.BeginSample(FAST_LIST_REMOVE_RANGE);
						_transforms.RemoveRange(index, length);
						_tweenStates.RemoveRange(index, length);
						_tweenPositions.RemoveRange(index, length);
						_tweenRotations.RemoveRange(index, length);
						_tweenScales.RemoveRange(index, length);
						_tweenPositionLifetimes.RemoveRange(index, length);
						_tweenRotationLifetimes.RemoveRange(index, length);
						_tweenScaleLifetimes.RemoveRange(index, length);

						// Shuffle all batches ahead of the current one so that their start indexes are adjusted back
						// based on the length of the batch we are removing.
						for (var j = i + 1; j < _tweenBatches.Length; j++)
						{
							var laterTweenBatch = _tweenBatches.buffer[j];
							laterTweenBatch.startIndex -= batch.length;
							_tweenBatches.buffer[j] = laterTweenBatch;
						}

						_tweenBatches.RemoveAt(i);
						_tweenBatchLifetimes.RemoveAt(i);
						_tweenBatchHandles.RemoveAt(i);
						Profiler.EndSample();
					}
				}
			}

			// Properly dispose of the native collections
			DisposeNativeTransformCollections();

			_nativeTweenBatches.Dispose();
			_nativeTweenBatchLifetimes.Dispose();

			Profiler.EndSample();

			Profiler.BeginSample(EVENT_COMPLETED_PROFILE);

			// After all sensitive native work has completed, kick out any and all completed events
			while(_tweenHandleCallbackEventQueue.Count > 0)
			{
				var tweenHandle = _tweenHandleCallbackEventQueue.Dequeue();
				_tweenHandlePool.AddLast(tweenHandle);

				tweenHandle.Completed?.Invoke();
			}

			Profiler.EndSample();
		}
	}
}
