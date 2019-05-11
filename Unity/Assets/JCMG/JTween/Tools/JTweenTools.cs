using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace JCMG.JTween
{
	internal static class JTweenTools
	{
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

		public static unsafe void CopyTweenPositionDirectlyToNativeArray(TweenPosition[] sourceArray, NativeArray<TweenPosition> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * TweenPosition.SizeOf());
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

		public static unsafe void CopyTweenScaleDirectlyToNativeArray(TweenScale[] sourceArray, NativeArray<TweenScale> destinationArray, int length)
		{
			fixed (void* arrayPointer = sourceArray)
			{
				UnsafeUtility.MemCpy(
					NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(destinationArray),
					arrayPointer,
					length * TweenScale.SizeOf());
			}
		}

		#endregion
	}
}
