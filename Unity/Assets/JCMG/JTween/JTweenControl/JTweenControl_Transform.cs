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
			int loopCount = 0)
		{
			_singleTransformTweener.Move(target, from, to, duration, spaceType, easeType, loopType, loopCount);
		}

		public void Scale(
			Transform target,
			Vector3 from,
			Vector3 to,
			float duration,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_singleTransformTweener.Scale(target, from, to, duration, easeType, loopType, loopCount);
		}

		public void Rotate(
			Transform target,
			Quaternion from,
			Quaternion to,
			float duration,
			SpaceType spaceType = SpaceType.World,
			EaseType easeType = EaseType.Linear,
			LoopType loopType = LoopType.None,
			int loopCount = 0)
		{
			_singleTransformTweener.Rotate(target, from, to, duration, spaceType, easeType, loopType, loopCount);
		}

		public void RotateOnAxis(
			Transform target,
			float angle,
			float duration,
			SpaceType spaceType,
			EaseType easeType,
			LoopType loopType,
			int loopCount,
			RotateMode rotateMode)
		{
			_singleTransformTweener.RotateOnAxis(target,
				angle,
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				rotateMode);
		}
	}
}
