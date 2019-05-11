using NUnit.Framework;
using UnityEngine;

namespace JCMG.JTween.Editor.Tests
{
	public class StructSizeTests
	{
		[Test]
		public void StructSizeTestsSimplePasses()
		{
			// When structs were being copied to and from native I had seen memcpy.string calls that caused
			// allocations, but did not when they were 40 or less bytes. From research this appears to be a
			// Mono JIT issue, but I still try to keep these as compact as possible and split up where GT 40 bytes.
			Assert.LessOrEqual(TweenTransformState.SizeOf(), 40, "TweenState Size: {0} > 40", TweenTransformState.SizeOf());
			Assert.LessOrEqual(TweenBatch.SizeOf(), 40, "TweenBatch Size: {0} > 40", TweenBatch.SizeOf());
			Assert.LessOrEqual(TweenLifetime.SizeOf(), 40, "TweenLifetime Size: {0} > 40", TweenLifetime.SizeOf());
			Assert.LessOrEqual(TweenRotation.SizeOf(), 40, "TweenRotation Size: {0} > 40", TweenRotation.SizeOf());
			Assert.LessOrEqual(TweenFloat4.SizeOf(), 40, "TweenFloat4 Size: {0} > 40", TweenFloat4.SizeOf());
			Assert.LessOrEqual(TweenFloat3.SizeOf(), 40, "TweenFloat3 Size: {0} > 40", TweenFloat3.SizeOf());
			Assert.LessOrEqual(TweenFloat2.SizeOf(), 40, "TweenFloat2 Size: {0} > 40", TweenFloat2.SizeOf());
			Assert.LessOrEqual(TweenFloat1.SizeOf(), 40, "TweenFloat1 Size: {0} > 40", TweenFloat1.SizeOf());

			Debug.LogFormat("TweenState Size: {0}", TweenTransformState.SizeOf());
			Debug.LogFormat("TweenBatch Size: {0}", TweenBatch.SizeOf());
			Debug.LogFormat("TweenLifetime Size: {0}", TweenLifetime.SizeOf());
			Debug.LogFormat("TweenRotation Size: {0}", TweenRotation.SizeOf());
			Debug.LogFormat("TweenFloat4 Size: {0}", TweenFloat4.SizeOf());
			Debug.LogFormat("TweenFloat3 Size: {0}", TweenFloat3.SizeOf());
			Debug.LogFormat("TweenFloat2 Size: {0}", TweenFloat2.SizeOf());
			Debug.LogFormat("TweenFloat1 Size: {0}", TweenFloat1.SizeOf());
		}
	}
}
