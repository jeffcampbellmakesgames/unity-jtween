using System;

namespace JCMG.JTween
{
	/// <summary>
	/// The base interface collection for <see cref="ITweenHandle"/>s.
	/// </summary>
	public interface ITweenCollection
	{
		/// <summary>
		/// Adds the <see cref="ITweenHandle"/> instance to the collection.
		/// </summary>
		/// <param name="tweenHandle"></param>
		void Add(ITweenHandle tweenHandle);

		/// <summary>
		/// Recycles all <see cref="ITweenHandle"/> instances from the collection and clears all local event
		/// listeners.
		/// </summary>
		void Clear();

		/// <summary>
		/// Recycles all <see cref="ITweenHandle"/> instances in the collection and removes them. All local event listeners
		/// will remain.
		/// </summary>
		void Recycle();

		/// <summary>
		/// Adds a listener that is invoked when the collection has completed.
		/// </summary>
		/// <param name="onComplete"></param>
		void AddOnComplete(Action onComplete);

		/// <summary>
		/// Adds a listener that is invoked when the collection has begun playing.
		/// </summary>
		/// <param name="onStart"></param>
		void AddOnStarted(Action onStart);
	}
}
