using System;

namespace JCMG.JTween
{
	/// <summary>
	/// A user reference to tween data that allows for safe manipulation of its state.
	/// </summary>
	public interface ITweenHandle
	{
		/// <summary>
		/// returns true if the tween is playing, otherwise false.
		/// </summary>
		/// <returns></returns>
		bool IsPlaying();

		/// <summary>
		/// Returns true if the tween is paused, otherwise false.
		/// </summary>
		/// <returns></returns>
		bool IsPaused();

		/// <summary>
		/// Returns true if the tween is completed, otherwise false.
		/// </summary>
		/// <returns></returns>
		bool IsCompleted();

		/// <summary>
		/// Plays the tween instance if paused or not completed. Any listeners added via
		/// <see cref="AddOnStartedListener"/> will be invoked.
		/// </summary>
		void Play();

		/// <summary>
		/// Pauses the tween instance if playing.
		/// </summary>
		void Pause();

		/// <summary>
		/// Rewinds the tween data back to its original state and immediately plays it.
		/// </summary>
		void Restart();

		/// <summary>
		/// Rewinds the tween data back to its original state and sets it as paused.
		/// </summary>
		void Rewind();

		/// <summary>
		/// Stops the tween instance if playing or paused and and marks it as completed. Any listeners added
		/// via <see cref="AddOnCompletedListener"/> will be invoked.
		/// </summary>
		void Stop();

		/// <summary>
		/// Immediately stops the tween and marks the tween as requiring recycling. Any local reference to
		/// this <see cref="ITweenHandle"/> instance should be cleared by setting it to null. If playing or
		/// paused, this will not invoke listeners added via <see cref="AddOnCompletedListener"/>.
		/// </summary>
		void Recycle();

		/// <summary>
		/// Adds an event listener that is called when the tween is started via <see cref="Play"/>.
		/// </summary>
		/// <param name="onStarted"></param>
		void AddOnStartedListener(Action onStarted);

		/// <summary>
		/// Adds an event listener that is called when the tween has completed or when <see cref="Stop"/> is
		/// called while playing/paused.
		/// </summary>
		/// <param name="onCompleted"></param>
		void AddOnCompletedListener(Action onCompleted);
	}
}
