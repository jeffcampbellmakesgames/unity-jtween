using JCMG.JTween;
using UnityEngine;

namespace SampleContent
{
	internal class WorldRotationExample : MonoBehaviour
	{
		private void Start()
		{
			transform.RotateY(180, 1, EaseType.Linear, LoopType.Restart, -1);
		}

		#if UNITY_EDITOR

		private void OnDrawGizmos()
		{
			UnityEditor.Handles.color = Color.green;
			UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, 1f);
		}

		#endif
	}
}
