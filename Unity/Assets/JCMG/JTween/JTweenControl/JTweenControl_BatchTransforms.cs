using System;
using UnityEngine;

namespace JCMG.JTween
{
	public sealed partial class JTweenControl
	{
		/// <summary>
		/// Creates a batch of movement tweens for the <see cref="Transform"/>[] <paramref name="targets"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Vector3"/>[] where the move from position should be assigned from.</param>
		/// <param name="toArray">The <see cref="Vector3"/>[] where the move to position should be assigned from.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween batch begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween batch completes (default is NULL).</param>
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

		/// <summary>
		/// Creates a batch of movement tweens for the <see cref="Transform"/>[] <paramref name="targets"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Vector3"/>[] where the move from position should be assigned from.</param>
		/// <param name="toArray">The <see cref="Vector3"/>[] where the move to position should be assigned from.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Creates a batch of movement tweens for a slice from <see cref="Transform"/>[] <paramref name="targets"/>
		/// starting at <paramref name="startIndex"/> to <paramref name="length"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Vector3"/>[] where the move from position should be assigned from.</param>
		/// <param name="toArray">The <see cref="Vector3"/>[] where the move to position should be assigned from.</param>
		/// <param name="startIndex">The index where the slice should start from in the parameter arrays.</param>
		/// <param name="length">The length from which values should copied in the parameter arrays starting from the <paramref name="startIndex"/>.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween batch begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween batch completes (default is NULL).</param>
		public void BatchMoveSlice(
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

		/// <summary>
		/// Creates a batch of movement tweens for a slice from <see cref="Transform"/>[] <paramref name="targets"/>
		/// starting at <paramref name="startIndex"/> to <paramref name="length"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Vector3"/>[] where the move from position should be assigned from.</param>
		/// <param name="toArray">The <see cref="Vector3"/>[] where the move to position should be assigned from.</param>
		/// <param name="startIndex">The index where the slice should start from in the parameter arrays.</param>
		/// <param name="length">The length from which values should copied in the parameter arrays starting from the <paramref name="startIndex"/>.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		public void BatchMoveSlice(
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

		/// <summary>
		/// Creates a batch of scale tweens for the <see cref="Transform"/>[] <paramref name="targets"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Vector3"/>[] where the from scale should be assigned from.</param>
		/// <param name="toArray">The <see cref="Vector3"/>[] where the to scale should be assigned from.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween batch begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween batch completes (default is NULL).</param>
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

		/// <summary>
		/// Creates a batch of scale tweens for the <see cref="Transform"/>[] <paramref name="targets"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Vector3"/>[] where the from scale should be assigned from.</param>
		/// <param name="toArray">The <see cref="Vector3"/>[] where the to scale should be assigned from.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Creates a batch of scale tweens for a slice from <see cref="Transform"/>[] <paramref name="targets"/>
		/// starting at <paramref name="startIndex"/> to <paramref name="length"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Vector3"/>[] where the from scale should be assigned from.</param>
		/// <param name="toArray">The <see cref="Vector3"/>[] where the to scale should be assigned from.</param>
		/// <param name="startIndex">The index where the slice should start from in the parameter arrays.</param>
		/// <param name="length">The length from which values should copied in the parameter arrays starting from the <paramref name="startIndex"/>.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween batch begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween batch completes (default is NULL).</param>
		public void BatchScaleSlice(
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

		/// <summary>
		/// Creates a batch of scale tweens for a slice from <see cref="Transform"/>[] <paramref name="targets"/>
		/// starting at <paramref name="startIndex"/> to <paramref name="length"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Vector3"/>[] where the from scale should be assigned from.</param>
		/// <param name="toArray">The <see cref="Vector3"/>[] where the to scale should be assigned from.</param>
		/// <param name="startIndex">The index where the slice should start from in the parameter arrays.</param>
		/// <param name="length">The length from which values should copied in the parameter arrays starting from the <paramref name="startIndex"/>.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		public void BatchScaleSlice(
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

		/// <summary>
		/// Creates a batch of rotation tweens for the <see cref="Transform"/>[] <paramref name="targets"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Quaternion"/>[] where the from rotation should be assigned from.</param>
		/// <param name="toArray">The <see cref="Quaternion"/>[] where the to rotation should be assigned from.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween batch begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween batch completes (default is NULL).</param>
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

		/// <summary>
		/// Creates a batch of rotation tweens for the <see cref="Transform"/>[] <paramref name="targets"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Quaternion"/>[] where the from rotation should be assigned from.</param>
		/// <param name="toArray">The <see cref="Quaternion"/>[] where the to rotation should be assigned from.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		public void BatchRotate(
			Transform[] targets,
			Quaternion[] fromArray,
			Quaternion[] toArray,
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
				0,
				targets.Length,
				duration,
				spaceType,
				easeType,
				loopType,
				loopCount,
				null,
				null,
				false,
				out tweenHandle);
		}

		/// <summary>
		/// Creates a batch of rotation tweens for a slice from <see cref="Transform"/>[] <paramref name="targets"/>
		/// starting at <paramref name="startIndex"/> to <paramref name="length"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Quaternion"/>[] where the from rotation should be assigned from.</param>
		/// <param name="toArray">The <see cref="Quaternion"/>[] where the to rotation should be assigned from.</param>
		/// <param name="startIndex">The index where the slice should start from in the parameter arrays.</param>
		/// <param name="length">The length from which values should copied in the parameter arrays starting from the <paramref name="startIndex"/>.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween batch begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween batch completes (default is NULL).</param>
		public void BatchRotateSlice(
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
				onComplete,
				false,
				out _invalidTweenHandle);
		}

		/// <summary>
		/// Creates a batch of rotation tweens for a slice from <see cref="Transform"/>[] <paramref name="targets"/>
		/// starting at <paramref name="startIndex"/> to <paramref name="length"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromArray">The <see cref="Quaternion"/>[] where the from rotation should be assigned from.</param>
		/// <param name="toArray">The <see cref="Quaternion"/>[] where the to rotation should be assigned from.</param>
		/// <param name="startIndex">The index where the slice should start from in the parameter arrays.</param>
		/// <param name="length">The length from which values should copied in the parameter arrays starting from the <paramref name="startIndex"/>.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		public void BatchRotateSlice(
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

		/// <summary>
		/// Creates a batch of tweens animating movement, rotation, and scaling for the <see cref="Transform"/>[] <paramref name="targets"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromPosArray">The <see cref="Vector3"/>[] where the from position should be assigned from.</param>
		/// <param name="toPosArray">The <see cref="Vector3"/>[] where the from position should be assigned from.</param>
		/// <param name="fromRotArray">The <see cref="Quaternion"/>[] where the from rotation should be assigned from.</param>
		/// <param name="toRotArray">The <see cref="Quaternion"/>[] where the to rotation should be assigned from.</param>
		/// <param name="fromScaleArray">The <see cref="Vector3"/>[] where the from scale should be assigned from.</param>
		/// <param name="toScaleArray">The <see cref="Vector3"/>[] where the to scale should be assigned from.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween batch begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween batch completes (default is NULL).</param>
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

		/// <summary>
		/// Creates a batch of tweens animating movement, rotation, and scaling for the <see cref="Transform"/>[] <paramref name="targets"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromPosArray">The <see cref="Vector3"/>[] where the from position should be assigned from.</param>
		/// <param name="toPosArray">The <see cref="Vector3"/>[] where the from position should be assigned from.</param>
		/// <param name="fromRotArray">The <see cref="Quaternion"/>[] where the from rotation should be assigned from.</param>
		/// <param name="toRotArray">The <see cref="Quaternion"/>[] where the to rotation should be assigned from.</param>
		/// <param name="fromScaleArray">The <see cref="Vector3"/>[] where the from scale should be assigned from.</param>
		/// <param name="toScaleArray">The <see cref="Vector3"/>[] where the to scale should be assigned from.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
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

		/// <summary>
		/// Creates a batch of tweens animating movement, rotation, and scaling for a slice from <see cref="Transform"/>[] <paramref name="targets"/>
		/// starting at <paramref name="startIndex"/> to <paramref name="length"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromPosArray">The <see cref="Vector3"/>[] where the from position should be assigned from.</param>
		/// <param name="toPosArray">The <see cref="Vector3"/>[] where the from position should be assigned from.</param>
		/// <param name="fromRotArray">The <see cref="Quaternion"/>[] where the from rotation should be assigned from.</param>
		/// <param name="toRotArray">The <see cref="Quaternion"/>[] where the to rotation should be assigned from.</param>
		/// <param name="fromScaleArray">The <see cref="Vector3"/>[] where the from scale should be assigned from.</param>
		/// <param name="toScaleArray">The <see cref="Vector3"/>[] where the to scale should be assigned from.</param>
		/// <param name="startIndex">The index where the slice should start from in the parameter arrays.</param>
		/// <param name="length">The length from which values should copied in the parameter arrays starting from the <paramref name="startIndex"/>.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		/// <param name="onStart">The <see cref="Action"/> that should be invoked when the tween batch begins playing (default is NULL).</param>
		/// <param name="onComplete">The <see cref="Action"/> that should be invoked when the tween batch completes (default is NULL).</param>
		public void BatchUpdateTransformsSlice(
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

		/// <summary>
		/// Creates a batch of tweens animating movement, rotation, and scaling for a slice from <see cref="Transform"/>[] <paramref name="targets"/>
		/// starting at <paramref name="startIndex"/> to <paramref name="length"/>.
		/// </summary>
		/// <param name="targets">The <see cref="Transform"/>[] that are the targets of this tween batch.</param>
		/// <param name="fromPosArray">The <see cref="Vector3"/>[] where the from position should be assigned from.</param>
		/// <param name="toPosArray">The <see cref="Vector3"/>[] where the from position should be assigned from.</param>
		/// <param name="fromRotArray">The <see cref="Quaternion"/>[] where the from rotation should be assigned from.</param>
		/// <param name="toRotArray">The <see cref="Quaternion"/>[] where the to rotation should be assigned from.</param>
		/// <param name="fromScaleArray">The <see cref="Vector3"/>[] where the from scale should be assigned from.</param>
		/// <param name="toScaleArray">The <see cref="Vector3"/>[] where the to scale should be assigned from.</param>
		/// <param name="startIndex">The index where the slice should start from in the parameter arrays.</param>
		/// <param name="length">The length from which values should copied in the parameter arrays starting from the <paramref name="startIndex"/>.</param>
		/// <param name="duration">The length of time in seconds that the tween batch should take to complete or one pass if looping.</param>
		/// <param name="tweenHandle">The <see cref="ITweenHandle"/> instance that will be initialized for this tween.</param>
		/// <param name="spaceType">The coordinate system the tween batch should operate in (default is World).</param>
		/// <param name="easeType">The type of easing the tween batch should use while playing (default is Linear).</param>
		/// <param name="loopType">The type of looping that should be used (default is None).</param>
		/// <param name="loopCount">If looping, the number of loops that should occur before completing. If set to -1, the tween will loop infinitely. (default is zero)</param>
		public void BatchUpdateTransformsSlice(
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
