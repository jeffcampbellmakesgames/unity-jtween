using JCMG.JTween;
using UnityEngine;

namespace SampleContent
{
	internal class SingleTweenEventExample : MonoBehaviour
	{
		[Header("Scene Refs")]
		[SerializeField]
		private Transform _objectOne;

		[SerializeField]
		private Transform _objectTwo;

		[SerializeField]
		private Transform _objectThree;

		[Header("Animation"), Space(5)]
		[SerializeField]
		private float _duration;

		[SerializeField]
		private EaseType _easeType;

		[SerializeField]
		private Vector3 _moveDirection;

		private Vector3 _gizmoTargetOne;
		private Vector3 _gizmoTargetTwo;
		private Vector3 _gizmoTargetThree;

		private void Start()
		{
			_gizmoTargetOne = _objectOne.position + _moveDirection;
			_gizmoTargetTwo = _objectTwo.position + _moveDirection;
			_gizmoTargetThree = _objectThree.position + _moveDirection;

			TweenObjectOne();
		}

		private void TweenObjectOne()
		{
			_objectOne.Move(
				_objectOne.position + _moveDirection,
				_duration,
				_easeType,
				LoopType.PingPong,
				1,
				onComplete: TweenObjectTwo);
		}

		private void TweenObjectTwo()
		{
			_objectTwo.Move(
				_objectTwo.position + _moveDirection,
				_duration,
				_easeType,
				LoopType.PingPong,
				1,
				onComplete: TweenObjectThree);
		}

		private void TweenObjectThree()
		{
			_objectThree.Move(
				_objectThree.position + _moveDirection,
				_duration,
				_easeType,
				LoopType.PingPong,
				1,
				onComplete: TweenObjectOne);
		}

		#if UNITY_EDITOR

		private void OnDrawGizmos()
		{
			if (_objectOne == null || _objectTwo == null || _objectThree == null)
			{
				return;
			}

			if (Application.isPlaying)
			{
				Gizmos.DrawLine(_objectOne.position, _gizmoTargetOne);
				Gizmos.DrawLine(_objectTwo.position, _gizmoTargetTwo);
				Gizmos.DrawLine(_objectThree.position, _gizmoTargetThree);
			}
			else
			{
				Gizmos.DrawLine(_objectOne.position, _objectOne.position + _moveDirection);
				Gizmos.DrawLine(_objectTwo.position, _objectTwo.position + _moveDirection);
				Gizmos.DrawLine(_objectThree.position, _objectThree.position + _moveDirection);
			}
		}

		#endif
	}
}
