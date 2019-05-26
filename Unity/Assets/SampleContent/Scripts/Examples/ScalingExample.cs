using JCMG.JTween;
using UnityEngine;

namespace SampleContent
{
	internal class ScalingExample : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _scaleTarget;

		[Min(0f)]
		[SerializeField]
		private float _duration;

		[SerializeField]
		private EaseType _easeType;

		[SerializeField]
		private LoopType _loopType;

		[Min(-1)]
		[SerializeField]
		private int _loopCount;

		private void Start()
		{
			transform.Scale(_scaleTarget, _duration, _easeType, _loopType, _loopCount);
		}

		#if UNITY_EDITOR

		private void Reset()
		{
			_duration = 1f;
			_loopType = LoopType.PingPong;
			_loopCount = -1;
		}

		private void OnDrawGizmos()
		{
			// Show the general bounds of the scale target for simple primitive meshes.
			UnityEditor.Handles.color = Color.green;
			UnityEditor.Handles.DrawWireCube(transform.position, _scaleTarget);
		}

		#endif
	}
}
