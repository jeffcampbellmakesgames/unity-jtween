﻿using Unity.Collections.LowLevel.Unsafe;

namespace JCMG.JTween
{
	internal struct TweenBatch
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

		public bool IncludesIndex(int index)
		{
			return startIndex <= index && startIndex + length > index;
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenBatch>();
		}
	}
}
