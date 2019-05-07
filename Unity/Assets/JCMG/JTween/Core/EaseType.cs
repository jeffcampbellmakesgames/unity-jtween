using System;

namespace JCMG.JTween
{
	[Serializable]
	public enum EaseType : byte
	{
		Linear,

		SineIn,
		SineOut,
		SineInOut,

		QuadIn,
		QuadOut,
		QuadInOut,

		CubicIn,
		CubicOut,
		CubicInOut,

		QuartIn,
		QuartOut,
		QuartInOut,

		QuintIn,
		QuintOut,
		QuintInOut,

		ExpoIn,
		ExpoOut,
		ExpoInOut,

		CircIn,
		CircOut,
		CircInOut,

		ElasticIn,
		ElasticOut,
		ElasticInOut,
		Punch,

		BackIn,
		BackOut,
		BackInOut,

		BounceIn,
		BounceOut,
		BounceInOut
	}
}
