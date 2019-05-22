using System;

namespace JCMG.JTween
{
	/// <summary>
	/// The type of looping the tween should use while running.
	/// </summary>
	[Serializable]
	public enum LoopType : byte
	{
		/// <summary>
		/// No looping.
		/// </summary>
		None,

		/// <summary>
		/// The tween should loop starting back from its original state animating towards its target state.
		/// </summary>
		Restart,

		/// <summary>
		/// The tween should loop from its target state back to its original state.
		/// </summary>
		PingPong
	}
}
