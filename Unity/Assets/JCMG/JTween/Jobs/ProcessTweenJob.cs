using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace JCMG.JTween
{
	[BurstCompile]
	internal struct ProcessTweenJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<TweenFloat3> tweenPositions;

		[ReadOnly]
		public NativeArray<TweenRotation> tweenRotations;

		[ReadOnly]
		public NativeArray<TweenFloat3> tweenScales;

		[WriteOnly]
		public NativeArray<float3> positions;

		[WriteOnly]
		public NativeArray<quaternion> rotations;

		[WriteOnly]
		public NativeArray<float3> scales;

		public NativeArray<TweenLifetime> tweenPositionLifetimes;

		public NativeArray<TweenLifetime> tweenRotationLifetimes;

		public NativeArray<TweenLifetime> tweenScaleLifetimes;

		public NativeArray<TweenTransformState> tweenStates;

		public float deltaTime;

		private const byte TRUE = 1;
		private const byte FALSE = 0;

		public void Execute(int i)
		{
			var tweenState = tweenStates[i];
			if (tweenState.isPlaying == FALSE)
			{
				return;
			}

			var tweenIsPlaying = false;
			if (tweenState.IsMovementEnabled())
			{
				var tweenLifetime = tweenPositionLifetimes[i];
				tweenLifetime.Update(deltaTime);
				tweenPositionLifetimes[i] = tweenLifetime;

				var progress = tweenLifetime.GetProgress();
				positions[i] = tweenPositions[i].Lerp(tweenLifetime.GetEase(), tweenLifetime.isReversed == TRUE);
				tweenIsPlaying = progress < 1f;
			}

			if (tweenState.IsRotationEnabled())
			{
				var tweenLifetime = tweenRotationLifetimes[i];
				tweenLifetime.Update(deltaTime);
				tweenRotationLifetimes[i] = tweenLifetime;

				var progress = tweenLifetime.GetProgress();
				rotations[i] = tweenRotations[i].GetRotation(
					tweenLifetime.GetEase(),
					tweenLifetime.isReversed == TRUE,
					tweenState.GetRotateMode());
				tweenIsPlaying = progress < 1f;
			}

			if (tweenState.IsScalingEnabled())
			{
				var tweenLifetime = tweenScaleLifetimes[i];
				tweenLifetime.Update(deltaTime);
				tweenScaleLifetimes[i] = tweenLifetime;

				var progress = tweenLifetime.GetProgress();
				scales[i] = tweenScales[i].Lerp(tweenLifetime.GetEase(), tweenLifetime.isReversed == TRUE);
				tweenIsPlaying = progress < 1f;
			}

			tweenState.isPlaying = tweenIsPlaying ? TRUE : FALSE;
			tweenStates[i] = tweenState;
		}
	}
}
