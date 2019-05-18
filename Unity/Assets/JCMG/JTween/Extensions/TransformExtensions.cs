using System;
using UnityEngine;

namespace JCMG.JTween
{
	public static class TransformExtensions
	{
		public static void Move(
			this Transform transform,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Move(
				transform,
				transform.position,
				to,
				duration,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void Move(
			this Transform transform,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Move(
				transform,
				transform.position,
				to,
				duration,
				out tweenHandle,
				SpaceType.World,
				easeType,
				loopType,
				loopCount);
		}

		public static void Move(
			this Transform transform,
			Vector3 from,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Move(
				transform,
				from,
				to,
				duration,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void Move(
			this Transform transform,
			Vector3 from,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Move(
				transform,
				from,
				to,
				duration,
				out tweenHandle,
				SpaceType.World,
				easeType,
				loopType,
				loopCount);
		}

		public static void MoveLocal(
			this Transform transform,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Move(
				transform,
				transform.localPosition,
				to,
				duration,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void MoveLocal(
			this Transform transform,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Move(
				transform,
				transform.localPosition,
				to,
				duration,
				out tweenHandle,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount);
		}

		public static void MoveLocal(
			this Transform transform,
			Vector3 from,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Move(
				transform,
				from,
				to,
				duration,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void MoveLocal(
			this Transform transform,
			Vector3 from,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Move(
				transform,
				from,
				to,
				duration,
				out tweenHandle,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount);
		}

		public static void Scale(
			this Transform transform,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Scale(
				transform,
				transform.localScale,
				to,
				duration,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void Scale(
			this Transform transform,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Scale(
				transform,
				transform.localScale,
				to,
				duration,
				out tweenHandle,
				easeType,
				loopType,
				loopCount);
		}

		public static void Scale(
			this Transform transform,
			Vector3 from,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Scale(
				transform,
				from,
				to,
				duration,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void Scale(
			this Transform transform,
			Vector3 from,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Scale(
				transform,
				from,
				to,
				duration,
				out tweenHandle,
				easeType,
				loopType,
				loopCount);
		}

		public static void Rotate(
			this Transform transform,
			Quaternion from,
			Quaternion to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Rotate(
				transform,
				from,
				to,
				duration,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void Rotate(
			this Transform transform,
			Quaternion from,
			Quaternion to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Rotate(
				transform,
				from,
				to,
				duration,
				out tweenHandle,
				SpaceType.World,
				easeType,
				loopType,
				loopCount);
		}

		public static void Rotate(
			this Transform transform,
			Quaternion to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Rotate(
				transform,
				transform.rotation,
				to,
				duration,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void Rotate(
			this Transform transform,
			Quaternion to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Rotate(
				transform,
				transform.rotation,
				to,
				duration,
				out tweenHandle,
				SpaceType.World,
				easeType,
				loopType,
				loopCount);
		}

		public static void RotateLocal(
			this Transform transform,
			Quaternion from,
			Quaternion to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Rotate(
				transform,
				from,
				to,
				duration,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void RotateLocal(
			this Transform transform,
			Quaternion from,
			Quaternion to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Rotate(
				transform,
				from,
				to,
				duration,
				out tweenHandle,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount);
		}

		public static void RotateLocal(
			this Transform transform,
			Quaternion to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.Rotate(
				transform,
				transform.localRotation,
				to,
				duration,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void RotateLocal(
			this Transform transform,
			Quaternion to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.Rotate(
				transform,
				transform.localRotation,
				to,
				duration,
				out tweenHandle,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount);
		}

		public static void RotateX(
			this Transform transform,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.X,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void RotateX(
			this Transform transform,
			float angle,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.X,
				out tweenHandle,
				SpaceType.World,
				easeType,
				loopType,
				loopCount);
		}

		public static void RotateY(
			this Transform transform,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.Y,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void RotateY(
			this Transform transform,
			float angle,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.Y,
				out tweenHandle,
				SpaceType.World,
				easeType,
				loopType,
				loopCount);
		}

		public static void RotateZ(
			this Transform transform,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.Z,
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void RotateZ(
			this Transform transform,
			float angle,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.Z,
				out tweenHandle,
				SpaceType.World,
				easeType,
				loopType,
				loopCount);
		}

		public static void RotateXLocal(
			this Transform transform,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.X,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void RotateXLocal(
			this Transform transform,
			float angle,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.X,
				out tweenHandle,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount);
		}

		public static void RotateYLocal(
			this Transform transform,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.Y,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void RotateYLocal(
			this Transform transform,
			float angle,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.Y,
				out tweenHandle,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount);
		}

		public static void RotateZLocal(
			this Transform transform,
			float angle,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.Z,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public static void RotateZLocal(
			this Transform transform,
			float angle,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			JTweenControl.Instance.RotateOnAxis(
				transform,
				angle,
				duration,
				RotateMode.Z,
				out tweenHandle,
				SpaceType.Local,
				easeType,
				loopType,
				loopCount);
		}
	}
}
