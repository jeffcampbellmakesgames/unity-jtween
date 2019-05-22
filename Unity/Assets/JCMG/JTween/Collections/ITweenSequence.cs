using System;

namespace JCMG.JTween
{
	/// <summary>
	/// A <see cref="ITweenHandle"/> collection whose contents are operated in succession. A started event is
	/// invoked when first played and completed once the last <see cref="ITweenHandle"/> instance has completed.
	/// </summary>
	public interface ITweenSequence : ITweenCollection
	{
		/// <summary>
		/// Pauses the current <see cref="ITweenHandle"/> instance in the sequence if playing.
		/// </summary>
		void Pause();

		/// <summary>
		/// If not playing, plays the first <see cref="ITweenHandle"/> instance in the sequence. Otherwise if
		/// the current <see cref="ITweenHandle"/> instance in the sequence is paused that will be played.
		/// </summary>
		void Play();

		/// <summary>
		/// Rewinds all <see cref="ITweenHandle"/> instances in the sequence and plays the first one.
		/// </summary>
		void Restart();

		/// <summary>
		/// Rewinds all <see cref="ITweenHandle"/> instances in the sequence and initialized the first one as
		/// paused.
		/// </summary>
		void Rewind();

		/// <summary>
		/// Stops the currently playing <see cref="ITweenHandle"/> instance in the sequence if any and marks
		/// it as complete.
		/// </summary>
		void Stop();

		/// <summary>
		/// Adds a listener that is invoked every time a <see cref="ITweenHandle"/> in the sequence has
		/// completed.
		/// </summary>
		/// <param name="onStep"></param>
		void AddOnStep(Action onStep);
	}
}
