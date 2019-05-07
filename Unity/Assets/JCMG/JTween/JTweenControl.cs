using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Profiling;

namespace JCMG.JTween
{
	public sealed partial class JTweenControl : Singleton<JTweenControl>
	{
		// Managed lists of tween data
		private readonly FastList<Transform> _transforms = new FastList<Transform>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenTransformState> _tweenStates = new FastList<TweenTransformState>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenPosition> _tweenPositions = new FastList<TweenPosition>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenRotation> _tweenRotations = new FastList<TweenRotation>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenScale> _tweenScales = new FastList<TweenScale>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenLifetime> _tweenPositionLifetimes = new FastList<TweenLifetime>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenLifetime> _tweenRotationLifetimes = new FastList<TweenLifetime>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		private readonly FastList<TweenLifetime> _tweenScaleLifetimes = new FastList<TweenLifetime>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		// Native collections of transforms and tween data
		private TransformAccessArray _transformAccessArray;
		private NativeArray<TweenTransformState> _nativeTweenStates;
		private NativeArray<TweenPosition> _nativeTweenPositions;
		private NativeArray<TweenRotation> _nativeTweenRotations;
		private NativeArray<TweenScale> _nativeTweenScales;
		private NativeArray<TweenLifetime> _nativePositionLifetimes;
		private NativeArray<TweenLifetime> _nativeRotationLifetimes;
		private NativeArray<TweenLifetime> _nativeScaleLifetimes;
		private NativeArray<float3> _nativePositions;
		private NativeArray<quaternion> _nativeRotations;
		private NativeArray<float3> _nativeScales;

		// Jobs
		private ProcessTweenJob _processTweenJob;
		private ApplyTweenToTransformJob _applyTweenToTransformJob;

		// JobHandles
		private JobHandle _processTweenJobHandle;
		private JobHandle applyTweenUpdates;

		// Internal state
		private bool _isJobScheduled;

		// Constants
		private const byte TRUE = 1;
		private const byte FALSE = 0;
		private const short INFINITE_LOOP = -1;

		protected override void Awake()
		{
			base.Awake();

			_transformAccessArray = new TransformAccessArray(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		}

		private void OnDestroy()
		{
			// Clean up all native collections currently in use.
			if (_transformAccessArray.isCreated)
			{
				_transformAccessArray.Dispose();
			}

			if (_nativeTweenStates.IsCreated)
			{
				_nativeTweenStates.Dispose();
			}

			if (_nativeTweenPositions.IsCreated)
			{
				_nativeTweenPositions.Dispose();
			}

			if (_nativeTweenRotations.IsCreated)
			{
				_nativeTweenRotations.Dispose();
			}

			if (_nativeTweenScales.IsCreated)
			{
				_nativeTweenScales.Dispose();
			}

			if (_nativePositionLifetimes.IsCreated)
			{
				_nativePositionLifetimes.Dispose();
			}

			if (_nativeRotationLifetimes.IsCreated)
			{
				_nativeRotationLifetimes.Dispose();
			}

			if (_nativeScaleLifetimes.IsCreated)
			{
				_nativeScaleLifetimes.Dispose();
			}

			if (_nativePositions.IsCreated)
			{
				_nativePositions.Dispose();
			}

			if (_nativeRotations.IsCreated)
			{
				_nativeRotations.Dispose();
			}

			if (_nativeScales.IsCreated)
			{
				_nativeScales.Dispose();
			}
		}

		private void Update()
		{
			// If we do not have any tweens to handle, return early.
			if (_transforms.Length == 0)
			{
				return;
			}

			// Create and setup native collections. Copy over existing data
			_nativeTweenStates = new NativeArray<TweenTransformState>(_tweenStates.Length, Allocator.TempJob);
			CopyTweenStateDirectlyToNativeArray(_tweenStates.buffer, _nativeTweenStates, _tweenStates.Length);

			_nativeTweenPositions = new NativeArray<TweenPosition>(_tweenPositions.Length, Allocator.TempJob);
			CopyTweenPositionDirectlyToNativeArray(_tweenPositions.buffer, _nativeTweenPositions, _tweenPositions.Length);

			_nativeTweenRotations = new NativeArray<TweenRotation>(_tweenRotations.Length, Allocator.TempJob);
			CopyTweenRotationDirectlyToNativeArray(_tweenRotations.buffer, _nativeTweenRotations, _tweenRotations.Length);

			_nativeTweenScales = new NativeArray<TweenScale>(_tweenScales.Length, Allocator.TempJob);
			CopyTweenScaleDirectlyToNativeArray(_tweenScales.buffer, _nativeTweenScales, _tweenScales.Length);

			_nativePositionLifetimes = new NativeArray<TweenLifetime>(_tweenPositionLifetimes.Length, Allocator.TempJob);
			CopyTweenLifetimeDirectlyToNativeArray(_tweenPositionLifetimes.buffer, _nativePositionLifetimes, _tweenPositionLifetimes.Length);

			_nativeRotationLifetimes = new NativeArray<TweenLifetime>(_tweenRotationLifetimes.Length, Allocator.TempJob);
			CopyTweenLifetimeDirectlyToNativeArray(_tweenRotationLifetimes.buffer, _nativeRotationLifetimes, _tweenRotationLifetimes.Length);

			_nativeScaleLifetimes = new NativeArray<TweenLifetime>(_tweenScaleLifetimes.Length, Allocator.TempJob);
			CopyTweenLifetimeDirectlyToNativeArray(_tweenScaleLifetimes.buffer, _nativeScaleLifetimes, _tweenScaleLifetimes.Length);

			_nativePositions = new NativeArray<float3>(_tweenPositions.Length, Allocator.TempJob);
			_nativeRotations = new NativeArray<quaternion>(_tweenRotations.Length, Allocator.TempJob);
			_nativeScales = new NativeArray<float3>(_tweenScales.Length, Allocator.TempJob);

			// Create and schedule Jobs
			_processTweenJob = new ProcessTweenJob
			{
				deltaTime = Time.deltaTime,
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

			// Create the job that will apply the transformed tween data to the transforms and mark the prior
			// job as a dependency
			_applyTweenToTransformJob = new ApplyTweenToTransformJob
			{
				tweenStates = _nativeTweenStates,
				positions = _nativePositions,
				rotations = _nativeRotations,
				scales = _nativeScales
			};
			applyTweenUpdates = _applyTweenToTransformJob.Schedule(_transformAccessArray, _processTweenJobHandle);
			_isJobScheduled = true;
		}

		private void LateUpdate()
		{
			// If a job was never scheduled, return.
			if (!_isJobScheduled)
			{
				return;
			}

			_isJobScheduled = false;

			// Complete the job and any dependencies.
			applyTweenUpdates.Complete();

			// Get the data we need back from the native collections or if tween completed remove it.
			CopyNativeArrayDirectlyToTweenState(_nativeTweenStates, _tweenStates.buffer);
			CopyNativeArrayDirectlyToTweenLifetime(_nativePositionLifetimes, _tweenPositionLifetimes.buffer);
			CopyNativeArrayDirectlyToTweenLifetime(_nativeRotationLifetimes, _tweenRotationLifetimes.buffer);
			CopyNativeArrayDirectlyToTweenLifetime(_nativeScaleLifetimes, _tweenScaleLifetimes.buffer);

			for (var i = _nativeTweenStates.Length - 1; i >= 0; i--)
			{
				var tweenState = _tweenStates.buffer[i];
				if (tweenState.isPlaying == FALSE)
				{
					const string TRANSFORM_REMOVE_SWAP_PROFILE_NAME = "JTweenControl.TransformAccessArray.RemoveAtSwapBack";
					Profiler.BeginSample(TRANSFORM_REMOVE_SWAP_PROFILE_NAME);
					_transformAccessArray.RemoveAtSwapBack(i);
					Profiler.EndSample();

					_transforms.RemoveAt(i);
					_tweenStates.RemoveAt(i);
					_tweenPositions.RemoveAt(i);
					_tweenRotations.RemoveAt(i);
					_tweenScales.RemoveAt(i);
					_tweenPositionLifetimes.RemoveAt(i);
					_tweenRotationLifetimes.RemoveAt(i);
					_tweenScaleLifetimes.RemoveAt(i);
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
		}

		#region Unsafe Array Copy Methods

		private unsafe void CopyTweenStateDirectlyToNativeArray(TweenTransformState[] sourceArray, NativeArray<TweenTransformState> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * (long)UnsafeUtility.SizeOf<TweenTransformState>());
			}
		}

		unsafe void CopyNativeArrayDirectlyToTweenState(NativeArray<TweenTransformState> sourceArray, TweenTransformState[] destinationArray)
		{
			fixed (void* arrayPointer = destinationArray)
			{
				UnsafeUtility.MemCpy(
					arrayPointer,
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(sourceArray),
					sourceArray.Length * (long)UnsafeUtility.SizeOf<TweenTransformState>());
			}
		}

		private unsafe void CopyTweenLifetimeDirectlyToNativeArray(TweenLifetime[] sourceArray, NativeArray<TweenLifetime> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * (long)UnsafeUtility.SizeOf<TweenLifetime>());
			}
		}

		unsafe void CopyNativeArrayDirectlyToTweenLifetime(NativeArray<TweenLifetime> sourceArray, TweenLifetime[] destinationArray)
		{
			fixed (void* arrayPointer = destinationArray)
			{
				UnsafeUtility.MemCpy(
					arrayPointer,
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(sourceArray),
					sourceArray.Length * (long)UnsafeUtility.SizeOf<TweenLifetime>());
			}
		}

		private unsafe void CopyTweenPositionDirectlyToNativeArray(TweenPosition[] sourceArray, NativeArray<TweenPosition> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * (long)UnsafeUtility.SizeOf<TweenPosition>());
			}
		}

		private unsafe void CopyTweenRotationDirectlyToNativeArray(TweenRotation[] sourceArray, NativeArray<TweenRotation> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * (long)UnsafeUtility.SizeOf<TweenRotation>());
			}
		}

		private unsafe void CopyTweenScaleDirectlyToNativeArray(TweenScale[] sourceArray, NativeArray<TweenScale> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * (long)UnsafeUtility.SizeOf<TweenScale>());
			}
		}

		#endregion
	}
}
