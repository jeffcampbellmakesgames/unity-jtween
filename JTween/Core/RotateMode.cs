using System;

namespace JCMG.JTween
{
	/// <summary>
	/// The mode a tween should use when animating rotation.
	/// </summary>
	[Serializable]
	public enum RotateMode : byte
	{
		/// <summary>
		/// Rotates an object from one quaternion to another.
		/// </summary>
		XYZ,

		/// <summary>
		/// Rotates an object around the X axis.
		/// </summary>
		X,

		/// <summary>
		/// Rotates an object around the Y axis.
		/// </summary>
		Y,

		/// <summary>
		/// Rotates an object around the Z axis.
		/// </summary>
		Z
	}
}
