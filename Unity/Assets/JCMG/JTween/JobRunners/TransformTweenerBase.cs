using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace JCMG.JTween
{
	internal abstract class TransformTweenerBase : TweenerBase
	{
		// Managed lists of tween data
		protected readonly FastList<Transform> _transforms = new FastList<Transform>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		protected readonly FastList<TweenTransformState> _tweenStates = new FastList<TweenTransformState>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		protected readonly FastList<TweenPosition> _tweenPositions = new FastList<TweenPosition>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		protected readonly FastList<TweenRotation> _tweenRotations = new FastList<TweenRotation>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		protected readonly FastList<TweenScale> _tweenScales = new FastList<TweenScale>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		protected readonly FastList<TweenLifetime> _tweenPositionLifetimes = new FastList<TweenLifetime>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		protected readonly FastList<TweenLifetime> _tweenRotationLifetimes = new FastList<TweenLifetime>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		protected readonly FastList<TweenLifetime> _tweenScaleLifetimes = new FastList<TweenLifetime>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		// Native collections of transforms and tween data
		protected TransformAccessArray _transformAccessArray;
		protected NativeArray<TweenTransformState> _nativeTweenStates;
		protected NativeArray<TweenPosition> _nativeTweenPositions;
		protected NativeArray<TweenRotation> _nativeTweenRotations;
		protected NativeArray<TweenScale> _nativeTweenScales;
		protected NativeArray<TweenLifetime> _nativePositionLifetimes;
		protected NativeArray<TweenLifetime> _nativeRotationLifetimes;
		protected NativeArray<TweenLifetime> _nativeScaleLifetimes;
		protected NativeArray<float3> _nativePositions;
		protected NativeArray<quaternion> _nativeRotations;
		protected NativeArray<float3> _nativeScales;

		// Jobs
		protected ProcessTweenJob _processTweenJob;
		protected ApplyTweenToTransformJob _applyTweenToTransformJob;

		// JobHandles
		protected JobHandle _processTweenJobHandle;
		protected JobHandle applyTweenUpdates;

		protected override void Setup()
		{
			_transformAccessArray = new TransformAccessArray(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		}

		protected override void Teardown()
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

		protected void CreateNativeTransformCollections()
		{
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
		}

		protected void SetupJobs()
		{
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
			_processTweenJobHandle = _processTweenJob.Schedule(_tweenStates.Length, 128);

			_applyTweenToTransformJob = new ApplyTweenToTransformJob
			{
				tweenStates = _nativeTweenStates,
				positions = _nativePositions,
				rotations = _nativeRotations,
				scales = _nativeScales
			};

			applyTweenUpdates = _applyTweenToTransformJob.Schedule(_transformAccessArray, _processTweenJobHandle);
		}

		protected void CopyNativeCollectionsToManaged()
		{
			JTweenTools.CopyNativeArrayDirectlyToTweenState(_nativeTweenStates, _tweenStates.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativePositionLifetimes, _tweenPositionLifetimes.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativeRotationLifetimes, _tweenRotationLifetimes.buffer);
			JTweenTools.CopyNativeArrayDirectlyToTweenLifetime(_nativeScaleLifetimes, _tweenScaleLifetimes.buffer);
		}

		protected void DisposeNativeTransformCollections()
		{
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
	}
}
