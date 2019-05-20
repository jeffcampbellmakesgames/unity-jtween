using System;

namespace JCMG.JTween
{
	internal sealed class TweenSequence : TweenCollectionBase, ITweenSequence
	{
		private int _index;

		private TweenHandle _currentTweenHandle;

		private Action _onStep;

		public override void Add(ITweenHandle tweenHandle)
		{
			tweenHandle.AddOnCompetedListener(OnTweenCompleted);

			_tweenList.Add((TweenHandle)tweenHandle);
		}

		public void AddOnStep(Action onStep)
		{
			_onStep += onStep;
		}

		public override void Clear()
		{
			base.Clear();

			_onStep = null;
		}

		public override void Play()
		{
			if (_currentTweenHandle == null && _tweenList.Count > 0 && _index == 0)
			{
				_currentTweenHandle = _tweenList[_index++];
				_currentTweenHandle.AddOnStartedListener(OnTweenStarted);
				_currentTweenHandle.Play();
			}
			else
			{
				_currentTweenHandle?.Play();
			}
		}

		public override void Rewind()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Rewind();
			}

			if (_tweenList.Count > 0)
			{
				_index = 1;
				_currentTweenHandle = _tweenList[0];
			}
			else
			{
				_index = 0;
			}
		}

		public override void Recycle()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Recycle();
			}

			_tweenList.Clear();
		}

		public override void Pause()
		{
			_currentTweenHandle?.Play();
		}

		public override void Stop()
		{
			_currentTweenHandle?.Stop();
		}

		public override void Restart()
		{
			for (var i = 0; i < _tweenList.Count; i++)
			{
				_tweenList[i].Rewind();
			}

			if (_tweenList.Count > 0)
			{
				_index = 1;
				_currentTweenHandle = _tweenList[0];
				_currentTweenHandle.Play();
			}
			else
			{
				_index = 0;
			}
		}

		private void OnTweenStarted()
		{
			_onStart?.Invoke();
		}

		private void OnTweenCompleted()
		{
			if (_index > _tweenList.Count - 1)
			{
				_onComplete?.Invoke();
			}
			else
			{
				_currentTweenHandle = _tweenList[_index++];
				_currentTweenHandle.Play();

				_onStep?.Invoke();
			}
		}
	}
}
