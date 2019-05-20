using System;

namespace JCMG.JTween
{
	public interface ITweenCollection
	{
		void Add(ITweenHandle tweenHandle);
		void AddOnComplete(Action onComplete);
		void AddOnStarted(Action onStart);
		void Clear();
		void Pause();
		void Play();
		void Recycle();
		void Restart();
		void Rewind();
		void Stop();
	}
}
