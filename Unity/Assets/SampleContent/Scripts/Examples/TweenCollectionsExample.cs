using JCMG.JTween;
using UnityEngine;

namespace SampleContent
{
	public class TweenCollectionsExample : MonoBehaviour
	{
		[Header("Scene Refs")]
		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		private Vector3 _center;

		[Header("Tween Set One Animation"), Space(5)]
		[Min(0)]
		[SerializeField]
		private float _setOneDuration;

		[Range(10, 180)]
		[SerializeField]
		private float _angle;

		[SerializeField]
		private EaseType _setOneEaseType;

		[Min(0)]
		[SerializeField]
		private float _radius;

		[Min(0)]
		[SerializeField]
		private float _innerRadius;

		[Header("Tween Set Two Animation"), Space(5)]
		[Min(0)]
		[SerializeField]
		private float _setTwoDuration;

		[SerializeField]
		private EaseType _setTwoEaseType;

		[Header("Tween Sequence Animation"), Space(5)]
		[Min(0)]
		[SerializeField]
		private float _sequenceThreeDuration;

		[SerializeField]
		private EaseType _sequenceThreeEaseType;

		private Transform[] _transforms;

		private ITweenSet _tweenSetOne;
		private ITweenSet _tweenSetTwo;
		private ITweenSequence _tweenSequence;

		private void Awake()
		{
			// Setup initial arrangement.
			var count = (int)(360 / _angle);
			_transforms = new Transform[count];

			var index = 0;
			var currentAngle = 0f;
			while (index < count)
			{
				var spawnPosition = GetCirclePos(_center, currentAngle, _radius);
				var newGameObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
				newGameObject.transform.LookAt(_center);

				_transforms[index] = newGameObject.transform;

				index++;

				currentAngle += _angle;
			}
		}

		private void Start()
		{
			_tweenSetOne = JTweenControl.Instance.NewSet();
			_tweenSetTwo = JTweenControl.Instance.NewSet();
			_tweenSequence = JTweenControl.Instance.NewSequence();

			var currentAngle = 0f;
			for (var i = 0; i < _transforms.Length; i++)
			{
				var innerRadiusPosition = GetCirclePos(_center, currentAngle, _innerRadius);

				ITweenHandle tweenHandle;
				_transforms[i].Move(
					innerRadiusPosition,
					_setOneDuration,
					out tweenHandle,
					_setOneEaseType);

				_tweenSetOne.Add(tweenHandle);

				_transforms[i].RotateY(
					360f,
					_setTwoDuration,
					out tweenHandle,
					_sequenceThreeEaseType);
				_tweenSetTwo.Add(tweenHandle);

				_transforms[i].Move(
					innerRadiusPosition,
					_transforms[i].position,
					_sequenceThreeDuration,
					out tweenHandle,
					_sequenceThreeEaseType);

				_tweenSequence.Add(tweenHandle);

				currentAngle += _angle;
			}

			_tweenSetOne.AddOnStarted(OnTweenSetStarted);
			_tweenSetOne.AddOnComplete(OnTweenSetCompleted);
			_tweenSetOne.AddOnComplete(_tweenSetTwo.Rewind);
			_tweenSetOne.AddOnComplete(_tweenSetTwo.Play);

			_tweenSetTwo.AddOnStarted(OnTweenSetStarted);
			_tweenSetTwo.AddOnComplete(OnTweenSetCompleted);
			_tweenSetTwo.AddOnComplete(_tweenSequence.Rewind);
			_tweenSetTwo.AddOnComplete(_tweenSequence.Play);

			_tweenSequence.AddOnStarted(OnTweenSequenceStarted);
			_tweenSequence.AddOnComplete(OnTweenSequenceCompleted);
			_tweenSequence.AddOnComplete(_tweenSetOne.Rewind);
			_tweenSequence.AddOnComplete(_tweenSetOne.Play);

			_tweenSetOne.Play();
		}

		private Vector3 GetCirclePos(Vector3 center, float angle, float radius)
		{
			Vector3 pos;
			pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
			pos.y = center.y;
			pos.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
			return pos;
		}

		private void OnTweenSetStarted()
		{
			//Debug.Log("Tween Set Started");
		}

		private void OnTweenSetCompleted()
		{
			//Debug.Log("Tween Set Completed");
		}

		private void OnTweenSequenceStarted()
		{
			//Debug.Log("Tween Sequence Started");
		}

		private void OnTweenSequenceCompleted()
		{
			//Debug.Log("Tween Sequence Completed");
		}

		#if UNITY_EDITOR

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(_center, 0.5f);

			UnityEditor.Handles.color = Color.green;
			UnityEditor.Handles.DrawWireDisc(_center, Vector3.up, _radius);

			UnityEditor.Handles.color = Color.cyan;
			UnityEditor.Handles.DrawWireDisc(_center, Vector3.up, _innerRadius);
		}

		#endif
	}
}
