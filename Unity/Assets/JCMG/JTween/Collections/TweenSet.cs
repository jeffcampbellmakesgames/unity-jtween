
namespace JCMG.JTween
{
	internal sealed class TweenSet : TweenCollectionBase, ITweenSet
	{
		public override void Add(ITweenHandle tweenHandle)
		{
			tweenHandle.AddOnStartedListener(OnTweenStarted);
			tweenHandle.AddOnCompetedListener(OnTweenCompleted);

			_tweenList.Add((TweenHandle)tweenHandle);
		}

		public override void Play()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Play();
			}
		}

		public override void Pause()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Pause();
			}
		}

		public override void Stop()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Stop();
			}
		}

		public override void Restart()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Restart();
			}

			_isStarted = false;
			_isCompleted = false;
		}

		public override void Rewind()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Rewind();
			}

			_isStarted = false;
			_isCompleted = false;
		}

		public override void Recycle()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Recycle();
			}

			_isStarted = false;
			_isCompleted = false;

			_tweenList.Clear();
		}

		private void OnTweenStarted()
		{
			if (_isStarted)
			{
				return;
			}

			_isStarted = true;

			_onStart?.Invoke();
		}

		private void OnTweenCompleted()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				if (!_tweenList[i].IsCompleted())
				{
					return;
				}
			}

			if (_isCompleted)
			{
				return;
			}

			_isCompleted = true;

			_onComplete?.Invoke();
		}
	}
}
