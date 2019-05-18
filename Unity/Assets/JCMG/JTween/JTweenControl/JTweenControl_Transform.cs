using System;
using UnityEngine;

namespace JCMG.JTween
{
	public sealed partial class JTweenControl
	{
		public void Move(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_singleTransformTweener.Move(
				target,
				from,
				to,
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete,
				false,
				out _invalidTweenHandle);
		}

		public void Move(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_singleTransformTweener.Move(
				target,
				from,
				to,
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				null,
				null,
				true,
				out tweenHandle);
		}

		public void Scale(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_singleTransformTweener.Scale(
				target,
				from,
				to,
				duration,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete,
				false,
				out _invalidTweenHandle);
		}

		public void Scale(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			out ITweenHandle tweenHandle,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_singleTransformTweener.Scale(
				target,
				from,
				to,
				duration,
				easeType,
				loopType,
				loopCount,
				null,
				null,
				true,
				out tweenHandle);
		}

		public void Rotate(
			Transform target,
			Quaternion from,
			Quaternion to,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_singleTransformTweener.Rotate(
				target,
				from,
				to,
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete,
				false,
				out _invalidTweenHandle);
		}

		public void Rotate(
			Transform target,
			Quaternion from,
			Quaternion to,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_singleTransformTweener.Rotate(
				target,
				from,
				to,
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				null,
				null,
				true,
				out tweenHandle);
		}

		public void RotateOnAxis(
			Transform target,
			float angle,
			float duration,
			RotateMode rotateMode,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_singleTransformTweener.RotateOnAxis(
				target,
				angle,
				duration,
				rotateMode,
				spaceType,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete,
				false,
				out _invalidTweenHandle);
		}

		public void RotateOnAxis(
			Transform target,
			float angle,
			float duration,
			RotateMode rotateMode,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_singleTransformTweener.RotateOnAxis(
				target,
				angle,
				duration,
				rotateMode,
				spaceType,
				easeType,
				loopType,
				loopCount,
				null,
				null,
				true,
				out tweenHandle);
		}
	}
}
