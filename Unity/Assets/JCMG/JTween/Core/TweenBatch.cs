using Unity.Collections.LowLevel.Unsafe;

namespace JCMG.JTween
{
	internal struct TweenBatch
	{
		public uint startIndex;
		public uint length;
		public byte isCompleted;

		public bool IncludesIndex(int index)
		{
			return startIndex <= index && startIndex + length > index;
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenBatch>();
		}
	}
}
