using System;
using UnityEngine;

namespace JCMG.JTween
{
	public sealed partial class JTweenControl
	{
		/// <summary>
		/// Moves the <see cref="Transform"/> <paramref name="target"/>.
		/// </summary>
		/// <param name="target">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The position the <see cref="Transform"/> will be moved from.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes (default is NULL).</param>
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

		/// <summary>
		/// Moves the <see cref="Transform"/> <paramref name="target"/>.
		/// </summary>
		/// <param name="target">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The position the <see cref="Transform"/> will be moved from.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Scales the <see cref="Transform"/> <paramref name="target"/>.
		/// </summary>
		/// <param name="target">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The scale the <see cref="Transform"/> will be animated from.</param>
		/// <param name="to">The scale the <see cref="Transform"/> will be animated to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes (default is NULL).</param>
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

		/// <summary>
		/// Scales the <see cref="Transform"/> <paramref name="target"/>.
		/// </summary>
		/// <param name="target">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The scale the <see cref="Transform"/> will be animated from.</param>
		/// <param name="to">The scale the <see cref="Transform"/> will be animated to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates the <see cref="Transform"/> <paramref name="target"/>.
		/// </summary>
		/// <param name="target">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The rotation the <see cref="Transform"/> will be animated from.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes (default is NULL).</param>
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

		/// <summary>
		/// Rotates the <see cref="Transform"/> <paramref name="target"/>.
		/// </summary>
		/// <param name="target">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The rotation the <see cref="Transform"/> will be animated from.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates the <see cref="Transform"/> <paramref name="target"/> around the the specified axis
		/// (RotateMode.XYZ is an invalid value and will cause an assertion).
		/// </summary>
		/// <param name="target">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle"></param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one pass if looping.</param>
		/// <param name="rotateMode"></param>
		/// <param name="spaceType">The coordinate system the tween should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes (default is NULL).</param>
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

		/// <summary>
		/// Rotates the <see cref="Transform"/> <paramref name="target"/> around the the specified axis
		/// (RotateMode.XYZ is an invalid value and will cause an assertion).
		/// </summary>
		/// <param name="target">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle"></param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one pass if looping.</param>
		/// <param name="rotateMode"></param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
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
