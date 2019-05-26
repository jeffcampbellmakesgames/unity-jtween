using System;

namespace JCMG.JTween
{
	[Flags]
	internal enum TweenStateType : byte
	{
		IsPlaying = 1,
		IsPaused = 2,
		IsCompleted = 4,
		RequiresRecycling = 8,
		HasHandle = 16,
		JustStarted = 32,
		JustEnded = 64
	}
}
