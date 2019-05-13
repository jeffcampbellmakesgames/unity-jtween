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
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				RotateMode.X,
				onStart,
				onComplete);
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
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				RotateMode.Y,
				onStart,
				onComplete);
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
				SpaceType.World,
				easeType,
				loopType,
				loopCount,
				RotateMode.Z,
				onStart,
				onComplete);
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
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				RotateMode.X);
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
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				RotateMode.Y,
				onStart,
				onComplete);
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
				SpaceType.Local,
				easeType,
				loopType,
				loopCount,
				RotateMode.Z,
				onStart,
				onComplete);
		}
	}
}
