using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Jobs;
using UnityEngine.Profiling;

namespace JCMG.JTween
{
	internal sealed class BatchTransformTweener : TransformTweenerBase
	{
		private class TweenBatchComparer : IComparer<TweenBatch>
		{
			public int Compare(TweenBatch x, TweenBatch y)
			{
				return x.startIndex.CompareTo(y.startIndex);
			}
		}

		private readonly FastList<TweenBatch> _tweenBatches = new FastList<TweenBatch>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenLifetime> _tweenBatchLifetime = new FastList<TweenLifetime>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		private TweenBatchComparer _batchComparer;

		public void BatchMove(
				Transform[] targets,
				Vector3[] fromArray,
				Vector3[] toArray,
				float duration,
				SpaceType spaceType = SpaceType.World,
				EaseType easeType = EaseType.Linear,
				LoopType loopType = LoopType.None,
				int loopCount = 0)
		{
			// Ensure that our arrays are non-null and equal length
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length == fromArray.Length && fromArray.Length == toArray.Length);

			var batchIndex = _transforms.Length;
			var batchLength = targets.Length;
			_tweenBatches.Add(new TweenBatch { startIndex = (uint)batchIndex, length = (uint)batchLength });
			_tweenBatchLifetime.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_transforms.AddRange(targets);
			for (var i = 0; i < batchLength; i++)
			{
				_transformAccessArray.Add(_transforms.buffer[i]);

				_tweenStates.Add(new TweenTransformState
				{
					isPlaying = TRUE,
					isMovementEnabled = TRUE,
					moveSpaceType = spaceType
				});

				_tweenPositions.Add(new TweenPosition { from = fromArray[i], to = toArray[i] });
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
		}

		public void BatchMove(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			// Ensure that our arrays are non-null and have sufficient capacity for the intended slice.
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length >= startIndex + length &&
						  fromArray.Length >= startIndex + length &&
						  fromArray.Length >= startIndex + length);

			var batchIndex = _transforms.Length;
			var batchLength = length;
			_tweenBatches.Add(new TweenBatch { startIndex = (uint)batchIndex, length = (uint)batchLength });
			_tweenBatchLifetime.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_transforms.AddRange(targets, startIndex, length);
			for (var i = 0; i < batchLength; i++)
			{
				var normalizedIndex = startIndex + i;
				var normalizedBatchIndex = batchIndex + i;
				_transformAccessArray.Add(_transforms.buffer[normalizedBatchIndex]);

				_tweenStates.Add(new TweenTransformState
				{
					isPlaying = TRUE,
					isMovementEnabled = TRUE,
					moveSpaceType = spaceType
				});

				_tweenPositions.Add(new TweenPosition { from = fromArray[normalizedIndex], to = toArray[normalizedIndex] });
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
		}

		public void BatchScale(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			// Ensure that our arrays are non-null and equal length
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length == fromArray.Length && fromArray.Length == toArray.Length);

			var batchIndex = _transforms.Length;
			var batchLength = targets.Length;
			_tweenBatches.Add(new TweenBatch { startIndex = (uint)batchIndex, length = (uint)batchLength });
			_tweenBatchLifetime.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_transforms.AddRange(targets);
			for (var i = 0; i < batchLength; i++)
			{
				_transformAccessArray.Add(_transforms.buffer[i]);

				_tweenStates.Add(new TweenTransformState
				{
					isPlaying = TRUE,
					isScalingEnabled = TRUE,
					moveSpaceType = spaceType
				});

				_tweenPositions.Add(new TweenPosition());
				_tweenRotations.Add(new TweenRotation());
				_tweenScales.Add(new TweenScale { from = fromArray[i], to = toArray[i] });

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
		}

		public void BatchScale(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			// Ensure that our arrays are non-null and have sufficient capacity for the intended slice.
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length >= startIndex + length &&
			              fromArray.Length >= startIndex + length &&
			              fromArray.Length >= startIndex + length);

			var batchIndex = _transforms.Length;
			var batchLength = length;
			_tweenBatches.Add(new TweenBatch { startIndex = (uint)batchIndex, length = (uint)batchLength });
			_tweenBatchLifetime.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_transforms.AddRange(targets, startIndex, length);
			for (var i = 0; i < batchLength; i++)
			{
				var normalizedIndex = startIndex + i;
				var normalizedBatchIndex = batchIndex + i;
				_transformAccessArray.Add(_transforms.buffer[normalizedBatchIndex]);

				_tweenStates.Add(new TweenTransformState
				{
					isPlaying = TRUE,
					isScalingEnabled = TRUE,
					moveSpaceType = spaceType
				});

				_tweenPositions.Add(new TweenPosition());
				_tweenRotations.Add(new TweenRotation());
				_tweenScales.Add(new TweenScale { from = fromArray[normalizedIndex], to = toArray[normalizedIndex] });

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
		}

		public void BatchRotate(
			Transform[] targets,
			Quaternion[] fromArray,
			Quaternion[] toArray,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			// Ensure that our arrays are non-null and equal length
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length == fromArray.Length && fromArray.Length == toArray.Length);

			var batchIndex = _transforms.Length;
			var batchLength = targets.Length;
			_tweenBatches.Add(new TweenBatch { startIndex = (uint)batchIndex, length = (uint)batchLength });
			_tweenBatchLifetime.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_transforms.AddRange(targets);
			for (var i = 0; i < batchLength; i++)
			{
				_transformAccessArray.Add(_transforms.buffer[i]);

				_tweenStates.Add(new TweenTransformState
				{
					isPlaying = TRUE,
					isScalingEnabled = TRUE,
					moveSpaceType = spaceType
				});

				_tweenPositions.Add(new TweenPosition());
				_tweenRotations.Add(new TweenRotation { from = fromArray[i], to = toArray[i] });
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
		}

		public void BatchRotate(
			Transform[] targets,
			Quaternion[] fromArray,
			Quaternion[] toArray,
			int startIndex,
			int length,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			// Ensure that our arrays are non-null and have sufficient capacity for the intended slice.
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromArray);
			Assert.IsNotNull(toArray);
			Assert.IsTrue(targets.Length >= startIndex + length &&
						  fromArray.Length >= startIndex + length &&
						  fromArray.Length >= startIndex + length);

			var batchIndex = _transforms.Length;
			var batchLength = length;
			_tweenBatches.Add(new TweenBatch { startIndex = (uint)batchIndex, length = (uint)batchLength });
			_tweenBatchLifetime.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_transforms.AddRange(targets, startIndex, length);
			for (var i = 0; i < batchLength; i++)
			{
				var normalizedIndex = startIndex + i;
				var normalizedBatchIndex = batchIndex + i;
				_transformAccessArray.Add(_transforms.buffer[normalizedBatchIndex]);

				_tweenStates.Add(new TweenTransformState
				{
					isPlaying = TRUE,
					isScalingEnabled = TRUE,
					moveSpaceType = spaceType
				});

				_tweenPositions.Add(new TweenPosition());
				_tweenRotations.Add(new TweenRotation { from = fromArray[normalizedIndex], to = toArray[normalizedIndex] });
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
		}

		public void BatchUpdateTransforms(
			Transform[] targets,
			Vector3[] fromPosArray,
			Vector3[] toPosArray,
			Quaternion[] fromRotArray,
			Quaternion[] toRotArray,
			Vector3[] fromScaleArray,
			Vector3[] toScaleArray,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			// Ensure that our arrays are non-null and have equal length
			Assert.IsNotNull(targets);
			Assert.IsNotNull(fromPosArray);
			Assert.IsNotNull(toPosArray);
			Assert.IsNotNull(fromRotArray);
			Assert.IsNotNull(toRotArray);
			Assert.IsNotNull(fromScaleArray);
			Assert.IsNotNull(toScaleArray);
			Assert.IsTrue(targets.Length == fromPosArray.Length &&
			              fromPosArray.Length == toPosArray.Length &&
			              toPosArray.Length == fromRotArray.Length &&
			              fromRotArray.Length == toRotArray.Length &&
			              toRotArray.Length == fromScaleArray.Length &&
			              fromScaleArray.Length == toScaleArray.Length);

			var batchIndex = _transforms.Length;
			_tweenBatches.Add(new TweenBatch { startIndex = (uint)batchIndex, length = (uint)targets.Length });
			_tweenBatchLifetime.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_transforms.AddRange(targets);
			for (var i = 0; i < targets.Length; i++)
			{
				_transformAccessArray.Add(_transforms.buffer[i]);

				_tweenStates.Add(new TweenTransformState
				{
					isPlaying = TRUE,
					isMovementEnabled = TRUE,
					isRotationEnabled = TRUE,
					isScalingEnabled = TRUE,
					moveSpaceType = spaceType
				});

				_tweenPositions.Add(new TweenPosition { from = fromPosArray[i], to = toPosArray[i] });
				_tweenRotations.Add(new TweenRotation { from = fromRotArray[i], to = toRotArray[i] });
				_tweenScales.Add(new TweenScale { from = fromScaleArray[i], to = toScaleArray[i] });

				var lifetime = new TweenLifetime
				{
					duration = duration,
					easeType = easeType,
					loopType = loopType,
					loopCount = (short)loopCount
				};
				_tweenPositionLifetimes.Add(lifetime);
				_tweenRotationLifetimes.Add(lifetime);
				_tweenScaleLifetimes.Add(lifetime);
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
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
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

			var batchIndex = _transforms.Length;
			var batchLength = length;
			_tweenBatches.Add(new TweenBatch { startIndex = (uint)batchIndex, length = (uint)batchLength });
			_tweenBatchLifetime.Add(new TweenLifetime
			{
				duration = duration,
				easeType = easeType,
				loopType = loopType,
				loopCount = (short)loopCount
			});
			_transforms.AddRange(targets, startIndex, length);
			for (var i = 0; i < batchLength; i++)
			{
				var normalizedIndex = startIndex + i;
				var normalizedBatchIndex = batchIndex + i;
				_transformAccessArray.Add(_transforms.buffer[normalizedBatchIndex]);

				_tweenStates.Add(new TweenTransformState
				{
					isPlaying = TRUE,
					isMovementEnabled = TRUE,
					isRotationEnabled = TRUE,
					isScalingEnabled = TRUE,
					moveSpaceType = spaceType
				});

				_tweenPositions.Add(new TweenPosition { from = fromPosArray[normalizedIndex], to = toPosArray[normalizedIndex] });
				_tweenRotations.Add(new TweenRotation { from = fromRotArray[normalizedIndex], to = toRotArray[normalizedIndex] });
				_tweenScales.Add(new TweenScale { from = fromScaleArray[normalizedIndex], to = toScaleArray[normalizedIndex] });

				var lifetime = new TweenLifetime
				{
					duration = duration,
					easeType = easeType,
					loopType = loopType,
					loopCount = (short)loopCount
				};
				_tweenPositionLifetimes.Add(lifetime);
				_tweenRotationLifetimes.Add(lifetime);
				_tweenScaleLifetimes.Add(lifetime);
			}
		}

		internal override void Setup()
		{
			base.Setup();

			_batchComparer = new TweenBatchComparer();
		}

		internal override void UpdateTweens()
		{
			Profiler.BeginSample(UPDATE_PROFILE);
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

			// Update batch progress
			for (var i = 0; i < _tweenBatchLifetime.Length; i++)
			{
				var batchLifetime = _tweenBatchLifetime.buffer[i];
				batchLifetime.Update(_deltaTime);
				_tweenBatchLifetime.buffer[i] = batchLifetime;

				if (batchLifetime.GetProgress() >= 1f)
				{
					var batch = _tweenBatches.buffer[i];
					batch.isCompleted = TRUE;
					_tweenBatches.buffer[i] = batch;
				}
			}

			// Schedule Jobs
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

			_processTweenJobHandle = _processTweenJob.Schedule(_nativeTweenStates.Length, 128);

			_applyTweenToTransformJob = new ApplyTweenToTransformJob
			{
				tweenStates = _nativeTweenStates,
				positions = _nativePositions,
				rotations = _nativeRotations,
				scales = _nativeScales
			};

			applyTweenUpdates =
				_applyTweenToTransformJob.Schedule(_transformAccessArray, _processTweenJobHandle);

			_isJobScheduled = true;

			Profiler.EndSample();
		}

		internal override void LateUpdateTweens()
		{
			Profiler.BeginSample(LATE_UPDATE_PROFILE);
			if (!_isJobScheduled)
			{
				Profiler.EndSample();
				return;
			}

			_isJobScheduled = false;

			// Complete the job and any dependencies
			applyTweenUpdates.Complete();

			// Get the data we need back from the native collections or if tween completed remove it.
			JTweenTools.CopyNativeArrayDirectlyToTweenState(_nativeTweenStates, _tweenStates.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativePositionLifetimes, _tweenPositionLifetimes.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativeRotationLifetimes, _tweenRotationLifetimes.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativeScaleLifetimes, _tweenScaleLifetimes.buffer);

			// Sort batches from earliest index to latest, check for any completed batches,
			// and then remove en masse tweens where their batch is complete.
			Array.Sort(_tweenBatches.buffer, 0, _tweenBatches.Length, _batchComparer);
			for (var i = _tweenBatches.Length - 1; i >= 0; i--)
			{
				var batch = _tweenBatches.buffer[i];
				if (batch.isCompleted == TRUE)
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

					//
					for (var j = i + 1; j < _tweenBatches.Length; j++)
					{
						var laterTweenBatch = _tweenBatches.buffer[j];
						laterTweenBatch.startIndex -= batch.length;
						_tweenBatches.buffer[j] = laterTweenBatch;
					}

					_tweenBatches.RemoveAt(i);
					_tweenBatchLifetime.RemoveAt(i);

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
