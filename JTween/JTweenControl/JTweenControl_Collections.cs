using System.Collections.Generic;

namespace JCMG.JTween
{
	public sealed partial class JTweenControl
	{
		private readonly LinkedList<TweenSet> _tweenSets = new LinkedList<TweenSet>();
		private readonly LinkedList<TweenSequence> _tweenSequences = new LinkedList<TweenSequence>();

		/// <summary>
		/// Creates a new instance of <see cref="ITweenSet"/> or returns a pooled instance.
		/// </summary>
		/// <returns></returns>
		public ITweenSet NewSet()
		{
			TweenSet tweenSet;
			if (_tweenSets.Count > 0)
			{
				tweenSet = _tweenSets.First.Value;
				_tweenSets.RemoveFirst();
			}
			else
			{
				tweenSet = new TweenSet();
			}

			return tweenSet;
		}

		/// <summary>
		/// Clears the contents of the <see cref="ITweenSet"/> <paramref name="tweenSet"/> and returns it to
		/// the pool.
		/// </summary>
		/// <param name="tweenSet">The <see cref="ITweenSet"/> instance to be recycled; any local reference to
		/// this should be cleared after it has been recycled.</param>
		public void RecycleSet(ITweenSet tweenSet)
		{
			tweenSet.Clear();
			_tweenSets.AddLast((TweenSet)tweenSet);
		}

		/// <summary>
		/// Creates a new instance of <see cref="ITweenSequence"/> or returns a pooled instance.
		/// </summary>
		/// <returns></returns>
		public ITweenSequence NewSequence()
		{
			TweenSequence tweenSequence;
			if (_tweenSequences.Count > 0)
			{
				tweenSequence = _tweenSequences.First.Value;
				_tweenSequences.RemoveFirst();
			}
			else
			{
				tweenSequence = new TweenSequence();
			}

			return tweenSequence;
		}

		/// <summary>
		/// Clears the contents of the <see cref="ITweenSequence"/> <paramref name="tweenSequence"/> and
		/// returns it to the pool.
		/// </summary>
		/// <param name="tweenSequence">The <see cref="ITweenSequence"/> instance to be recycled; any local
		/// reference to this should be cleared after it has been recycled.</param>
		public void RecycleSequence(ITweenSequence tweenSequence)
		{
			_tweenSequences.AddLast((TweenSequence)tweenSequence);
		}
	}
}
