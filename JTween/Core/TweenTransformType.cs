using System;

namespace JCMG.JTween
{
	[Flags]
	internal enum TweenTransformType : byte
	{
		Movement = 1,
		Rotation = 2,
		Scaling = 4
	}
}
