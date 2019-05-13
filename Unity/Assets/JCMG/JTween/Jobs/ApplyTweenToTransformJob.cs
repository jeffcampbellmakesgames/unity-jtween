﻿using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Jobs;

namespace JCMG.JTween
{
	[BurstCompile]
	internal struct ApplyTweenToTransformJob : IJobParallelForTransform
	{
		[ReadOnly]
		public NativeArray<TweenTransformState> tweenStates;

		[ReadOnly]
		public NativeArray<float3> positions;

		[ReadOnly]
		public NativeArray<quaternion> rotations;

		[ReadOnly]
		public NativeArray<float3> scales;

		public void Execute(int i, TransformAccess transform)
		{
			var tweenState = tweenStates[i];
			if (tweenState.IsMovementEnabled())
			{
				if (tweenState.IsMovementInWorldSpace())
				{
					transform.position = positions[i];
				}
				else
				{
					transform.localPosition = positions[i];
				}
			}

			if (tweenState.IsRotationEnabled())
			{
				if (tweenState.IsRotationInWorldSpace())
				{
					transform.rotation = rotations[i];
				}
				else
				{
					transform.localRotation = rotations[i];
				}
			}

			if (tweenState.IsScalingEnabled())
			{
				transform.localScale = scales[i];
			}
		}
	}
}
