using NUnit.Framework;

namespace JCMG.JTween.Editor.Tests
{
	public class StructSizeTests
	{
		[Test]
		public void StructSizeTestsSimplePasses()
		{
			// When structs were being copied to and from native I had seen memcpy.string calls that caused
			// allocations, but did not when they were 40 or less bytes. From research this appears to be a
			// Mono issue.
			Assert.LessOrEqual(TweenTransformState.SizeOf(), 40, "TweenState Size: {0} > 40", TweenTransformState.SizeOf());
			Assert.LessOrEqual(TweenLifetime.SizeOf(), 40, "TweenLifetime Size: {0} > 40", TweenLifetime.SizeOf());
			Assert.LessOrEqual(TweenPosition.SizeOf(), 40, "TweenPosition Size: {0} > 40", TweenPosition.SizeOf());
			Assert.LessOrEqual(TweenRotation.SizeOf(), 40, "TweenRotation Size: {0} > 40", TweenRotation.SizeOf());
			Assert.LessOrEqual(TweenScale.SizeOf(), 40, "TweenScale Size: {0} > 40", TweenScale.SizeOf());
		}
	}
}
