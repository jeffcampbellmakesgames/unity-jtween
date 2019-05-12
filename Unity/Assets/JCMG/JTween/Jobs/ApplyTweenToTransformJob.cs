using Unity.Burst;
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

		private const byte TRUE = 1;
		private const byte FALSE = 0;

		public void Execute(int i, TransformAccess transform)
		{
			var tweenState = tweenStates[i];
			if (tweenState.IsMovementEnabled())
			{
				if (tweenState.moveSpaceType == SpaceType.World)
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
				if (tweenState.rotateSpaceType == SpaceType.World)
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
