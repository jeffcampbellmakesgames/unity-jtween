using JCMG.JTween;
using UnityEditor;
using UnityEngine;

namespace SampleContent
{
	internal class LocalRotationExample : MonoBehaviour
	{
		private void Start()
		{
			transform.RotateYLocal(180, 1, loopType:LoopType.Restart, loopCount:-1);
		}

		private void OnDrawGizmos()
		{
			Handles.color = Color.green;
			Handles.DrawWireDisc(transform.position, transform.up, 1f);
		}
	}
}
