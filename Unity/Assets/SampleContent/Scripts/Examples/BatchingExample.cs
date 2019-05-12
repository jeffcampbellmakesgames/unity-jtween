using JCMG.JTween;
using UnityEngine;

namespace SampleContent
{
	internal class BatchingExample : MonoBehaviour
	{
		[Header("Scene Refs")]
		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		private Vector3 _center;

		[Header("UX"), Space(5)]
		[SerializeField]
		private Material _material;

		[Header("Animation"), Space(5)]
		[Range(10, 180)]
		[SerializeField]
		private float _angle;

		[SerializeField]
		private EaseType _easeType;

		[Min(0)]
		[SerializeField]
		private float _radius;

		[Min(0)]
		[SerializeField]
		private float _innerRadius;

		private Transform[] _transforms;

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

				newGameObject.GetComponent<MeshRenderer>().material = _material;

				_transforms[index] = newGameObject.transform;

				index++;

				currentAngle += _angle;
			}
		}

		private void Start()
		{
			var fromArray = new Vector3[_transforms.Length];
			fromArray.PopulatePositionArray(_transforms, SpaceType.World);

			var toArray = new Vector3[_transforms.Length];
			var currentAngle = 0f;
			for (var i = 0; i < _transforms.Length; i++)
			{
				toArray[i] = GetCirclePos(_center, currentAngle, _innerRadius);
				currentAngle += _angle;
			}

			JTweenControl.Instance.BatchMove(
				_transforms,
				fromArray,
				toArray,
				1,
				easeType: _easeType,
				loopType: LoopType.PingPong,
				loopCount: -1);
		}

		private Vector3 GetCirclePos(Vector3 center, float angle, float radius)
		{
			Vector3 pos;
			pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
			pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
			pos.z = center.z;
			return pos;
		}

		#if UNITY_EDITOR

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(_center, 0.5f);

			UnityEditor.Handles.color = Color.green;
			UnityEditor.Handles.DrawWireDisc(_center, Vector3.forward, _radius);

			UnityEditor.Handles.color = Color.cyan;
			UnityEditor.Handles.DrawWireDisc(_center, Vector3.forward, _innerRadius);
		}

		#endif
	}
}
