using System;

namespace JCMG.JTween
{
	public interface ITweenHandle
	{
		void Play();
		void Pause();
		void Restart();
		void Stop();
		void Recycle();
		void AddOnStartedListener(Action onStarted);
		void AddOnCompetedListener(Action onCompleted);
	}
}
