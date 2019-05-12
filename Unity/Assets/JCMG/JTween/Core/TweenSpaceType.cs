using System;

namespace JCMG.JTween
{
	[Flags]
	internal enum TweenSpaceType : byte
	{
		LocalMovement = 1,
		WorldMovement = 2,
		LocalRotation = 4,
		WorldRotation = 8
	}
}
