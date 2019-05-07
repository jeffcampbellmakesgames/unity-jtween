using JCMG.JTween;
using UnityEngine;

namespace SampleContent
{
	public class WorldMovementExample : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _destination;

		private void Start()
		{
			// This movement tween will move this transform in world space to the target area.
			gameObject.transform.Move(_destination, 2, EaseType.BounceOut, LoopType.Restart, 5);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(gameObject.transform.position, _destination);
		}
	}
}
