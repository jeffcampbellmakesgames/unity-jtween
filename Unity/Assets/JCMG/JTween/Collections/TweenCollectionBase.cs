using System;
using System.Collections.Generic;

namespace JCMG.JTween
{
	internal abstract class TweenCollectionBase : ITweenCollection
	{
		protected List<TweenHandle> _tweenList;

		protected Action _onStart;

		protected Action _onComplete;

		protected bool _isStarted;

		protected bool _isCompleted;

		protected TweenCollectionBase()
		{
			_tweenList = new List<TweenHandle>();
		}

		// Abstract methods for collections.
		public abstract void Add(ITweenHandle tweenHandle);

		// Abstract methods mapping ITween methods.
		public abstract void Play();
		public abstract void Pause();
		public abstract void Stop();
		public abstract void Restart();
		public abstract void Rewind();
		public abstract void Recycle();

		public void Clear()
		{
			Recycle();

			_isStarted = false;
			_isCompleted = false;

			_onStart = null;
			_onComplete = null;
		}

		public void AddOnStarted(Action onStart)
		{
			_onStart += onStart;
		}

		public void AddOnComplete(Action onComplete)
		{
			_onComplete += onComplete;
		}
	}
}
