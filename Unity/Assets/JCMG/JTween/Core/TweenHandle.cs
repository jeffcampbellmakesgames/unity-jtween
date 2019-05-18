using System;

namespace JCMG.JTween
{
	internal class TweenHandle : ITweenHandle
	{
		internal Action Started;

		internal Action Completed;

		internal TweenHandleActionType actionType;

		private readonly TweenerBase _tweenerBase;

		public TweenHandle(TweenerBase tweenerBase)
		{
			_tweenerBase = tweenerBase;
		}

		public void Play()
		{
			actionType = TweenHandleActionType.Play;
			_tweenerBase.QueueTweenHandleAction(this);
		}

		public void Pause()
		{
			actionType = TweenHandleActionType.Pause;
			_tweenerBase.QueueTweenHandleAction(this);
		}

		public void Restart()
		{
			actionType = TweenHandleActionType.Restart;
			_tweenerBase.QueueTweenHandleAction(this);
		}

		public void Stop()
		{
			actionType = TweenHandleActionType.Stop;
			_tweenerBase.QueueTweenHandleAction(this);
		}

		public void Recycle()
		{
			actionType = TweenHandleActionType.Recycle;
			_tweenerBase.QueueTweenHandleAction(this);
		}

		public void AddOnStartedListener(Action onStart)
		{
			Started += onStart;
		}

		public void AddOnCompetedListener(Action onCompleted)
		{
			Completed += onCompleted;
		}

		internal void Reset()
		{
			actionType = TweenHandleActionType.None;
			Started = null;
			Completed = null;
		}
	}
}
