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
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
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
				onComplete);
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
				duration,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
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
				onComplete);
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
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
		}

		public void BatchRotate(
			Transform[] targets,
			Quaternion[] fromArray,
			Quaternion[] toArray,
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
				onStart,
				onComplete);
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
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				onStart,
				onComplete);
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
				onComplete);
		}
	}
}
