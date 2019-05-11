using UnityEngine;

namespace JCMG.JTween
{
	internal abstract class TweenerBase : MonoBehaviour
	{
		// Constants
		protected const byte TRUE = 1;
		protected const byte FALSE = 0;

		protected const string UPDATE_PROFILE = "Update";
		protected const string LATE_UPDATE_PROFILE = "LateUpdate";
		protected const string TRANSFORM_ACCESS_ARRAY_REMOVE_PROFILE = "TransformAccessArray.RemoveAtSwapBack";
		protected const string FAST_LIST_REMOVE_AT = "FastList.RemoveAt";
		protected const string FAST_LIST_REMOVE_RANGE = "FastList.RemoveRange";

		// Internal state
		protected float _deltaTime;
		protected bool _isJobScheduled;

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
