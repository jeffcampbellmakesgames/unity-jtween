using System;

namespace JCMG.JTween
{
	/// <summary>
	/// The coordinate space system the tween should operate with regards to.
	/// </summary>
	[Serializable]
	public enum SpaceType : byte
	{
		/// <summary>
		/// The world space coordinate system.
		/// </summary>
		World,

		/// <summary>
		/// The coordinate system with regards to the parent object.
		/// </summary>
		Local
	}
}
