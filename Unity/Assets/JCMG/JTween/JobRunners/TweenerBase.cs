using UnityEngine;

namespace JCMG.JTween
{
	internal abstract class TweenerBase : MonoBehaviour
	{
		// Event Queues

		/// <summary>
		/// An event queue for tween callbacks to notify external subscribers.
		/// </summary>
		protected readonly FastList<TweenHandle> _tweenHandleCallbackEventQueue = new FastList<TweenHandle>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		/// <summary>
		/// An event queue for user actions to manipulate tween data
		/// </summary>
		protected readonly FastList<TweenHandle> _tweenHandleActionEventQueue = new FastList<TweenHandle>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		// Pools for external use
		protected readonly FastList<TweenHandle> _tweenHandlePool = new FastList<TweenHandle>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		// Internal state
		protected float _deltaTime;
		protected bool _isJobScheduled;

		// Constants
		protected const string UPDATE_PROFILE = "Update";
		protected const string LATE_UPDATE_PROFILE = "LateUpdate";
		protected const string EVENT_STARTED_PROFILE = "Update.OnStartCallbacks";
		protected const string EVENT_COMPLETED_PROFILE = "LateUpdate.OnCompleteCallbacks";
		protected const string TRANSFORM_ACCESS_ARRAY_REMOVE_PROFILE = "TransformAccessArray.RemoveAtSwapBack";
		protected const string FAST_LIST_REMOVE_AT = "FastList.RemoveAt";
		protected const string FAST_LIST_REMOVE_RANGE = "FastList.RemoveRange";

		protected const TweenStateType NO_HANDLE_START = TweenStateType.IsPlaying | TweenStateType.JustStarted;

		protected const TweenStateType HANDLE_START_PAUSED =
			TweenStateType.IsPaused | TweenStateType.JustStarted | TweenStateType.HasHandle;

		protected const TweenStateType HANDLE_START_PLAYING =
			TweenStateType.IsPlaying | TweenStateType.JustStarted | TweenStateType.HasHandle;

		internal void QueueTweenHandleAction(TweenHandle tweenHandle)
		{
			_tweenHandleActionEventQueue.Add(tweenHandle);
		}

		protected abstract void Teardown();
		protected abstract void UpdateTweens();
		protected abstract void LateUpdateTweens();

		protected virtual void Awake()
		{
			Setup();
		}

		protected virtual void Setup()
		{
			for (var i = 0; i < _tweenHandlePool.Capacity; i++)
			{
				_tweenHandlePool.Add(new TweenHandle(this));
			}
		}

		protected virtual void OnDestroy()
		{
			Teardown();
		}

		protected virtual void Update()
		{
			_deltaTime = Time.deltaTime;

			UpdateTweens();
		}

		protected virtual void LateUpdate()
		{
			LateUpdateTweens();
		}

		protected TweenHandle GetNextAvailableTweenAccessor()
		{
			TweenHandle tweenAccessor;
			if (_tweenHandlePool.Length > 0)
			{
				tweenAccessor = _tweenHandlePool.PopLast();
				tweenAccessor.Reset();
			}
			else
			{
				tweenAccessor = new TweenHandle(this);
			}

			return tweenAccessor;
		}
	}
}
