using JCMG.JTween;
using UnityEngine;

namespace SampleContent
{
	internal class LocalMovementExample : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _destination;

		private Vector3 _target;

		private void Start()
		{
			// This movement tween will move this transform in local space relative to its parent to the target.
			gameObject.transform.MoveLocal(_destination, 2, EaseType.BounceOut, LoopType.Restart, 5);

			// Get original local point for gizmo
			_target = gameObject.transform.TransformPoint(_destination);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			if (Application.isPlaying)
			{
				Gizmos.DrawLine(gameObject.transform.position, _target);
			}
			else
			{
				Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.TransformPoint(_destination));
			}
		}
	}
}
