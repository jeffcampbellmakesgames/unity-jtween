using JCMG.JTween;
using UnityEditor;
using UnityEngine;

namespace SampleContent
{
	internal class WorldRotationExample : MonoBehaviour
	{
		private void Start()
		{
			transform.RotateY(180, 1, EaseType.Linear, LoopType.Restart, -1);
		}

		private void OnDrawGizmos()
		{
			Handles.color = Color.green;
			Handles.DrawWireDisc(transform.position, Vector3.up, 1f);
		}
	}
}
