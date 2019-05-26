using System.Collections.Generic;
using JCMG.JTween;
using UnityEngine;

namespace SampleContent
{
	internal class BatchTweenEventExample : MonoBehaviour
	{
		[Header("Scene Refs")]
		[SerializeField]
		private Transform[] _objectGroupOne;

		[SerializeField]
		private Transform[] _objectGroupTwo;

		[SerializeField]
		private Transform[] _objectGroupThree;

		[Header("Animation"), Space(5)]
		[SerializeField]
		private float _duration;

		[SerializeField]
		private EaseType _easeType;

		[SerializeField]
		private Vector3 _moveDirection;

		private Vector3[] _oneFromTargets;
		private Vector3[] _oneToTargets;

		private Vector3[] _twoFromTargets;
		private Vector3[] _twoToTargets;

		private Vector3[] _threeFromTargets;
		private Vector3[] _threeToTargets;

		private List<Transform> _transforms;
		private Vector3[] _gizmoTargets;

		private void Start()
		{
			// Tween Targets
			_oneFromTargets = new Vector3[_objectGroupOne.Length];
			_oneFromTargets.PopulatePositionArray(_objectGroupOne, SpaceType.World);
			_oneToTargets = PopulateTweenToTargets(_objectGroupOne);

			_twoFromTargets = new Vector3[_objectGroupTwo.Length];
			_twoFromTargets.PopulatePositionArray(_objectGroupTwo, SpaceType.World);
			_twoToTargets = PopulateTweenToTargets(_objectGroupTwo);

			_threeFromTargets = new Vector3[_objectGroupThree.Length];
			_threeFromTargets.PopulatePositionArray(_objectGroupThree, SpaceType.World);
			_threeToTargets = PopulateTweenToTargets(_objectGroupThree);

			// Gizmos
			_transforms = new List<Transform>();
			_transforms.AddRange(_objectGroupOne);
			_transforms.AddRange(_objectGroupTwo);
			_transforms.AddRange(_objectGroupThree);

			_gizmoTargets = PopulateTweenToTargets(_transforms.ToArray());

			// Kick off first tween
			TweenObjectOne();
		}

		private void TweenObjectOne()
		{
			JTweenControl.Instance.BatchMove(
				_objectGroupOne,
				_oneFromTargets,
				_oneToTargets,
				_duration,
				easeType: _easeType,
				loopType: LoopType.PingPong,
				loopCount: 1,
				onComplete: TweenObjectTwo);
		}

		private void TweenObjectTwo()
		{
			JTweenControl.Instance.BatchMove(
				_objectGroupTwo,
				_twoFromTargets,
				_twoToTargets,
				_duration,
				easeType: _easeType,
				loopType: LoopType.PingPong,
				loopCount: 1,
				onComplete: TweenObjectThree);
		}

		private void TweenObjectThree()
		{
			JTweenControl.Instance.BatchMove(
				_objectGroupThree,
				_threeFromTargets,
				_threeToTargets,
				_duration,
				easeType: _easeType,
				loopType: LoopType.PingPong,
				loopCount: 1,
				onComplete: TweenObjectOne);
		}

		private Vector3[] PopulateTweenToTargets(Transform[] transforms)
		{
			var targets = new Vector3[transforms.Length];
			for (var i = 0; i < transforms.Length; i++)
			{
				targets[i] = transforms[i].position + _moveDirection;
			}

			return targets;
		}

		#if UNITY_EDITOR

		private void OnDrawGizmos()
		{
			if (_objectGroupOne == null || _objectGroupTwo == null || _objectGroupThree == null)
			{
				return;
			}

			if (Application.isPlaying)
			{
				for (var i = 0; i < _transforms.Count; i++)
				{
					Gizmos.DrawLine(_transforms[i].position, _gizmoTargets[i]);
				}
			}
			else
			{
				for (var i = 0; i < _objectGroupOne.Length; i++)
				{
					if (_objectGroupOne[i] == null)
					{
						continue;
					}

					Gizmos.DrawLine(_objectGroupOne[i].position, _objectGroupOne[i].position + _moveDirection);
				}

				for (var i = 0; i < _objectGroupTwo.Length; i++)
				{
					if (_objectGroupTwo[i] == null)
					{
						continue;
					}

					Gizmos.DrawLine(_objectGroupTwo[i].position, _objectGroupTwo[i].position + _moveDirection);
				}

				for (var i = 0; i < _objectGroupThree.Length; i++)
				{
					if (_objectGroupThree[i] == null)
					{
						continue;
					}

					Gizmos.DrawLine(_objectGroupThree[i].position, _objectGroupThree[i].position + _moveDirection);
				}
			}
		}

		#endif
	}
}
