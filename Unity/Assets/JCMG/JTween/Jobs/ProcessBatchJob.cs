using Unity.Collections;
using Unity.Jobs;

namespace JCMG.JTween
{
	internal struct ProcessBatchJob : IJobParallelFor
	{
		public NativeArray<TweenLifetime> batchLifetimes;

		public NativeArray<TweenTransformBatchState> tweenBatches;

		public float deltaTime;

		public void Execute(int index)
		{
			var tweenBatch = tweenBatches[index];
			if (tweenBatch.IsCompleted() || tweenBatch.IsPaused())
			{
				return;
			}

			var lifetime = batchLifetimes[index];
			lifetime.Update(deltaTime);
			batchLifetimes[index] = lifetime;

			if (lifetime.GetProgress() >= 1f)
			{
				if (!tweenBatch.HasHandle())
				{
					tweenBatch.state |= TweenStateType.RequiresRecycling;
				}

				tweenBatch.state |= TweenStateType.IsCompleted;
				tweenBatch.state |= TweenStateType.JustEnded;
				tweenBatch.state &= ~TweenStateType.IsPlaying;
				tweenBatches[index] = tweenBatch;
			}
		}
	}
}
