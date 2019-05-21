namespace JCMG.JTween
{
	/// <summary>
	/// A <see cref="ITweenHandle"/> collection whose contents are operated on all at once. A started event is
	/// invoked when first played and completed once all <see cref="ITweenHandle"/> instances have completed.
	/// </summary>
	public interface ITweenSet : ITweenCollection
	{
		/// <summary>
		/// Plays all <see cref="ITweenHandle"/> instances in the <see cref="ITweenSet"/>.
		/// </summary>
		void Play();

		/// <summary>
		/// Pauses all <see cref="ITweenHandle"/> instances in the <see cref="ITweenSet"/>.
		/// </summary>
		void Pause();

		/// <summary>
		/// Rewinds all <see cref="ITweenHandle"/> instances in the <see cref="ITweenSet"/> and plays them.
		/// </summary>
		void Restart();

		/// <summary>
		/// Rewinds all <see cref="ITweenHandle"/> instances in the <see cref="ITweenSet"/> and pauses them.
		/// </summary>
		void Rewind();

		/// <summary>
		/// Stops all <see cref="ITweenHandle"/> instances in the <see cref="ITweenSet"/> and marks them as
		/// complete.
		/// </summary>
		void Stop();
	}
}
