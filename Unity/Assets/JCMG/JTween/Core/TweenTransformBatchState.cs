using Unity.Collections.LowLevel.Unsafe;

namespace JCMG.JTween
{
	internal struct TweenTransformBatchState
	{
		public uint startIndex;
		public uint length;
		public TweenStateType state;

		public bool IsPlaying()
		{
			return (state & TweenStateType.IsPlaying) == TweenStateType.IsPlaying;
		}

		public bool IsPaused()
		{
			return (state & TweenStateType.IsPaused) == TweenStateType.IsPaused;
		}

		public bool IsCompleted()
		{
			return (state & TweenStateType.IsCompleted) == TweenStateType.IsCompleted;
		}

		public bool HasHandle()
		{
			return (state & TweenStateType.HasHandle) == TweenStateType.HasHandle;
		}

		public bool JustStarted()
		{
			return (state & TweenStateType.JustStarted) == TweenStateType.JustStarted;
		}

		public bool JustEnded()
		{
			return (state & TweenStateType.JustEnded) == TweenStateType.JustEnded;
		}

		public bool RequiresRecycling()
		{
			return (state & TweenStateType.RequiresRecycling) == TweenStateType.RequiresRecycling;
		}

		public bool IncludesIndex(int index)
		{
			return startIndex <= index && startIndex + length > index;
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenTransformBatchState>();
		}
	}
}
