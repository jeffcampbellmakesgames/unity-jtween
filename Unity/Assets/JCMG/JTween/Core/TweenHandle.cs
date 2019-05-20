using System;

namespace JCMG.JTween
{
	internal class TweenHandle : ITweenHandle
	{
		internal Action Started;

		internal Action Completed;

		internal TweenHandleActionType actionType;

		internal TweenStateType state;

		private readonly TweenerBase _tweenerBase;

		public TweenHandle(TweenerBase tweenerBase)
		{
			_tweenerBase = tweenerBase;
		}

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

		public bool HasHandle()
		{
			return (state & TweenStateType.HasHandle) == TweenStateType.HasHandle;
		}

		public bool JustStarted()
		{
			return (state & TweenStateType.JustStarted) == TweenStateType.JustStarted;
		}

		public bool JustEnded()
		{
			return (state & TweenStateType.JustEnded) == TweenStateType.JustEnded;
		}

		public bool RequiresRecycling()
		{
			return (state & TweenStateType.RequiresRecycling) == TweenStateType.RequiresRecycling;
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

		public void Rewind()
		{
			actionType = TweenHandleActionType.Rewind;
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
