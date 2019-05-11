using Unity.Collections;
using Unity.Jobs;

namespace JCMG.JTween
{
	internal struct ProcessBatchJob : IJobParallelFor
	{
		public NativeArray<TweenLifetime> batchLifetimes;

		public NativeArray<TweenBatch> tweenBatches;

		public float deltaTime;

		private const byte TRUE = 1;
		private const byte FALSE = 0;

		public void Execute(int index)
		{
			var lifetime = batchLifetimes[index];
			lifetime.Update(deltaTime);
			batchLifetimes[index] = lifetime;

			if (lifetime.GetProgress() >= 1f)
			{
				var tweenBatch = tweenBatches[index];
				tweenBatch.isCompleted = TRUE;
				tweenBatches[index] = tweenBatch;
			}
		}
	}
}
