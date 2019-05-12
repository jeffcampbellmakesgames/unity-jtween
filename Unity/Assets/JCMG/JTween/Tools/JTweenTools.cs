using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace JCMG.JTween
{
	internal static class JTweenTools
	{
		public static TweenSpaceType GetTweenSpaceTypeFromRotateMode(RotateMode rotateMode)
		{
			TweenSpaceType spaceType;
			switch (rotateMode)
			{
				case RotateMode.XYZ:
					spaceType = TweenSpaceType.RotateModeXYZ;
					break;
				case RotateMode.X:
					spaceType = TweenSpaceType.RotateX;
					break;
				case RotateMode.Y:
					spaceType = TweenSpaceType.RotateY;
					break;
				case RotateMode.Z:
					spaceType = TweenSpaceType.RotateZ;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(rotateMode), rotateMode, null);
			}

			return spaceType;
		}

		#region Unsafe Array Copy Methods

		public static unsafe void CopyTweenStateDirectlyToNativeArray(TweenTransformState[] sourceArray, NativeArray<TweenTransformState> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * TweenTransformState.SizeOf());
			}
		}

		public static unsafe void CopyNativeArrayDirectlyToTweenState(NativeArray<TweenTransformState> sourceArray, TweenTransformState[] destinationArray)
		{
			fixed (void* arrayPointer = destinationArray)
			{
				UnsafeUtility.MemCpy(
					arrayPointer,
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(sourceArray),
					sourceArray.Length * TweenTransformState.SizeOf());
			}
		}

		public static unsafe void CopyTweenLifetimeDirectlyToNativeArray(TweenLifetime[] sourceArray, NativeArray<TweenLifetime> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * TweenLifetime.SizeOf());
			}
		}

		public static unsafe void CopyNativeArrayDirectlyToTweenLifetime(NativeArray<TweenLifetime> sourceArray, TweenLifetime[] destinationArray)
		{
			fixed (void* arrayPointer = destinationArray)
			{
				UnsafeUtility.MemCpy(
					arrayPointer,
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(sourceArray),
					sourceArray.Length * TweenLifetime.SizeOf());
			}
		}

		public static unsafe void CopyTweenBatchDirectlyToNativeArray(TweenBatch[] sourceArray, NativeArray<TweenBatch> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * TweenBatch.SizeOf());
			}
		}

		public static unsafe void CopyNativeArrayDirectlyToTweenBatch(NativeArray<TweenBatch> sourceArray, TweenBatch[] destinationArray)
		{
			fixed (void* arrayPointer = destinationArray)
			{
				UnsafeUtility.MemCpy(
					arrayPointer,
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(sourceArray),
					sourceArray.Length * TweenBatch.SizeOf());
			}
		}

		public static unsafe void CopyTween3DirectlyToNativeArray(TweenFloat3[] sourceArray, NativeArray<TweenFloat3> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * TweenFloat3.SizeOf());
			}
		}

		public static unsafe void CopyTweenRotationDirectlyToNativeArray(TweenRotation[] sourceArray, NativeArray<TweenRotation> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * TweenRotation.SizeOf());
			}
		}

		#endregion
	}
}
