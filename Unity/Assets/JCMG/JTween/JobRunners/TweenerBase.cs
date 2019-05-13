using UnityEngine;

namespace JCMG.JTween
{
	internal abstract class TweenerBase : MonoBehaviour
	{
		// Managed collections for events.
		protected readonly FastList<TweenEvent> _tweenBatchEvents = new FastList<TweenEvent>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);
		protected readonly FastList<TweenEvent> _eventQueue = new FastList<TweenEvent>(RuntimeConstants.DEFAULT_FAST_LIST_SIZE);

		// Internal state
		protected float _deltaTime;
		protected bool _isJobScheduled;

		// Constants
		protected const byte TRUE = 1;
		protected const byte FALSE = 0;

		protected const string UPDATE_PROFILE = "Update";
		protected const string LATE_UPDATE_PROFILE = "Update.LateUpdate";
		protected const string EVENT_STARTED_PROFILE = "OnCompleteCallbacks";
		protected const string EVENT_COMPLETED_PROFILE = "LateUpdate.OnCompleteCallbacks";
		protected const string TRANSFORM_ACCESS_ARRAY_REMOVE_PROFILE = "TransformAccessArray.RemoveAtSwapBack";
		protected const string FAST_LIST_REMOVE_AT = "FastList.RemoveAt";
		protected const string FAST_LIST_REMOVE_RANGE = "FastList.RemoveRange";

		protected abstract void Setup();
		protected abstract void Teardown();
		protected abstract void UpdateTweens();
		protected abstract void LateUpdateTweens();

		protected virtual void Awake()
		{
			Setup();
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
	}
}
