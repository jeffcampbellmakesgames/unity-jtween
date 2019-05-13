using System;

namespace JCMG.JTween
{
	[Flags]
	internal enum TweenStateType : byte
	{
		IsPlaying = 1,
		IsPaused = 2,
		IsCompleted = 4,
		JustStarted = 8
	}
}
