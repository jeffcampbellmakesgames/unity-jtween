using System;
using UnityEngine;

namespace JCMG.JTween
{
	public sealed partial class JTweenControl
	{
		public void BatchMove(
				Transform[] targets,
				Vector3[] fromArray,
				Vector3[] toArray,
				float duration,
				SpaceType spaceType = SpaceType.World,
				EaseType easeType = EaseType.Linear,
				LoopType loopType = LoopType.None,
				int loopCount = 0,
				Action onStart = null,
				Action onComplete = null)
		{
			_batchTransformTweener.BatchMove(
				targets,
				fromArray,
				toArray,
				0,
				targets.Length,
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

		public void BatchMove(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_batchTransformTweener.BatchMove(
				targets,
				fromArray,
				toArray,
				0,
				targets.Length,
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

		public void BatchMove(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_batchTransformTweener.BatchMove(
				targets,
				fromArray,
				toArray,
				startIndex,
				length,
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

		public void BatchMove(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_batchTransformTweener.BatchMove(
				targets,
				fromArray,
				toArray,
				startIndex,
				length,
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

		public void BatchScale(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_batchTransformTweener.BatchScale(
				targets,
				fromArray,
				toArray,
				0,
				targets.Length,
				duration,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete,
				false,
				out _invalidTweenHandle);
		}

		public void BatchScale(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_batchTransformTweener.BatchScale(
				targets,
				fromArray,
				toArray,
				0,
				targets.Length,
				duration,
				easeType,
				loopType,
				loopCount,
				null,
				null,
				true,
				out tweenHandle);
		}

		public void BatchScale(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_batchTransformTweener.BatchScale(
				targets,
				fromArray,
				toArray,
				startIndex,
				length,
				duration,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete,
				false,
				out _invalidTweenHandle);
		}

		public void BatchScale(
			Transform[] targets,
			Vector3[] fromArray,
			Vector3[] toArray,
			int startIndex,
			int length,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_batchTransformTweener.BatchScale(
				targets,
				fromArray,
				toArray,
				startIndex,
				length,
				duration,
				easeType,
				loopType,
				loopCount,
				null,
				null,
				true,
				out tweenHandle);
		}

		public void BatchRotate(
			Transform[] targets,
			Quaternion[] fromArray,
			Quaternion[] toArray,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_batchTransformTweener.BatchRotate(
				targets,
				fromArray,
				toArray,
				0,
				targets.Length,
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

		public void BatchRotate(
			Transform[] targets,
			Quaternion[] fromArray,
			Quaternion[] toArray,
			int startIndex,
			int length,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_batchTransformTweener.BatchRotate(
				targets,
				fromArray,
				toArray,
				startIndex,
				length,
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

		public void BatchUpdateTransforms(
			Transform[] targets,
			Vector3[] fromPosArray,
			Vector3[] toPosArray,
			Quaternion[] fromRotArray,
			Quaternion[] toRotArray,
			Vector3[] fromScaleArray,
			Vector3[] toScaleArray,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_batchTransformTweener.BatchUpdateTransforms(
				targets,
				fromPosArray,
				toPosArray,
				fromRotArray,
				toRotArray,
				fromScaleArray,
				toScaleArray,
				0,
				targets.Length,
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

		public void BatchUpdateTransforms(
			Transform[] targets,
			Vector3[] fromPosArray,
			Vector3[] toPosArray,
			Quaternion[] fromRotArray,
			Quaternion[] toRotArray,
			Vector3[] fromScaleArray,
			Vector3[] toScaleArray,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_batchTransformTweener.BatchUpdateTransforms(
				targets,
				fromPosArray,
				toPosArray,
				fromRotArray,
				toRotArray,
				fromScaleArray,
				toScaleArray,
				0,
				targets.Length,
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

		public void BatchUpdateTransforms(
			Transform[] targets,
			Vector3[] fromPosArray,
			Vector3[] toPosArray,
			Quaternion[] fromRotArray,
			Quaternion[] toRotArray,
			Vector3[] fromScaleArray,
			Vector3[] toScaleArray,
			int startIndex,
			int length,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0,
			Action onStart = null,
			Action onComplete = null)
		{
			_batchTransformTweener.BatchUpdateTransforms(
				targets,
				fromPosArray,
				toPosArray,
				fromRotArray,
				toRotArray,
				fromScaleArray,
				toScaleArray,
				startIndex,
				length,
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

		public void BatchUpdateTransforms(
			Transform[] targets,
			Vector3[] fromPosArray,
			Vector3[] toPosArray,
			Quaternion[] fromRotArray,
			Quaternion[] toRotArray,
			Vector3[] fromScaleArray,
			Vector3[] toScaleArray,
			int startIndex,
			int length,
			float duration,
			out ITweenHandle tweenHandle,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_batchTransformTweener.BatchUpdateTransforms(
				targets,
				fromPosArray,
				toPosArray,
				fromRotArray,
				toRotArray,
				fromScaleArray,
				toScaleArray,
				startIndex,
				length,
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
	}
}
