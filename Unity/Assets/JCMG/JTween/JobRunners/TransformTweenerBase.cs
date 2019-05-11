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

		internal override void Setup()
		{
			_transformAccessArray = new TransformAccessArray(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		}

		internal override void Teardown()
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
	}
}
