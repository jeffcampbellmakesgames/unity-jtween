using System;
using UnityEngine;

namespace JCMG.JTween
{
	public static class TransformExtensions
	{
		/// <summary>
		/// Moves a transform in world space to position <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to in world space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Moves a transform in world space to position <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to in world space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Moves a transform in world space from position <see cref="Vector3"/> <paramref name="from"/> to
		/// position <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The position the <see cref="Transform"/> will be moved from in world space.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to in world space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Moves a transform in world space from position <see cref="Vector3"/> <paramref name="from"/> to
		/// position <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The position the <see cref="Transform"/> will be moved from in world space.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to in world space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Moves a transform in local space to position <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to in local space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Moves a transform in local space to position <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to in local space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Moves a transform in local space from position <see cref="Vector3"/> <paramref name="from"/> to
		/// position <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The position the <see cref="Transform"/> will be moved from in local space.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to in local space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Moves a transform in local space from position <see cref="Vector3"/> <paramref name="from"/> to
		/// position <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The position the <see cref="Transform"/> will be moved from in local space.</param>
		/// <param name="to">The position the <see cref="Transform"/> will be moved to in local space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Scales this <see cref="Transform"/> to scale <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The scale the <see cref="Transform"/> will be animated to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Scales this <see cref="Transform"/> to scale <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The scale the <see cref="Transform"/> will be animated to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Scales this <see cref="Transform"/> from scale <see cref="Vector3"/> <paramref name="from"/> to
		/// scale <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The scale the <see cref="Transform"/> will be animated from.</param>
		/// <param name="to">The scale the <see cref="Transform"/> will be animated to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Scales this <see cref="Transform"/> from scale <see cref="Vector3"/> <paramref name="from"/> to
		/// scale <see cref="Vector3"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The scale the <see cref="Transform"/> will be animated from.</param>
		/// <param name="to">The scale the <see cref="Transform"/> will be animated to.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> from rotation <see cref="Quaternion"/> <paramref name="from"/>
		/// to rotation <see cref="Quaternion"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The rotation the <see cref="Transform"/> will be animated from in world space.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to in world space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> from rotation <see cref="Quaternion"/> <paramref name="from"/>
		/// to rotation <see cref="Quaternion"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The rotation the <see cref="Transform"/> will be animated from in world space.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to in world space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> to rotation <see cref="Quaternion"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to in world space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> to rotation <see cref="Quaternion"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to in world space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> from rotation <see cref="Quaternion"/> <paramref name="from"/>
		/// to rotation <see cref="Quaternion"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The rotation the <see cref="Transform"/> will be animated from in local space.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to in local space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> from rotation <see cref="Quaternion"/> <paramref name="from"/>
		/// to rotation <see cref="Quaternion"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="from">The rotation the <see cref="Transform"/> will be animated from in local space.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to in local space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> to rotation <see cref="Quaternion"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to in local space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> to rotation <see cref="Quaternion"/> <paramref name="to"/>.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="to">The rotation the <see cref="Transform"/> will be animated to in local space.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> around the X axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around the world X axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> around the X axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around the world X axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> around the Y axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around the world Y axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> around the Y axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around the world Y axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> around the Z axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around the world Z axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in world space this <see cref="Transform"/> around the Z axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around the world Z axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> around the X axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around its local X axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> around the X axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around its local X axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> around the Y axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around its local Y axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> around the Y axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around its local Y axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> around the Z axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around its local Z axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween begins playing
		/// (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween completes
		/// (default is NULL).</param>
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

		/// <summary>
		/// Rotates in local space this <see cref="Transform"/> around the Z axis.
		/// </summary>
		/// <param name="transform">The <see cref="Transform"/> that is the target of this tween.</param>
		/// <param name="angle">The angle in degrees that this <see cref="Transform"/> will be rotated in
		/// around its local Z axis.</param>
		/// <param name="duration">The length of time in seconds that the tween should take to complete or one
		/// pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this
		/// tween.</param>
		/// <param name="easeType">The type of easing the tween should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If
		/// set to -1, the tween will loop infinitely. (default is zero)</param>
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
