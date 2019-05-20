using System;

namespace JCMG.JTween
{
	public interface ITweenHandle
	{
		bool IsPlaying();
		bool IsPaused();
		bool IsCompleted();
		void Play();
		void Pause();
		void Restart();
		void Rewind();
		void Stop();
		void Recycle();
		void AddOnStartedListener(Action onStarted);
		void AddOnCompetedListener(Action onCompleted);
	}
}
